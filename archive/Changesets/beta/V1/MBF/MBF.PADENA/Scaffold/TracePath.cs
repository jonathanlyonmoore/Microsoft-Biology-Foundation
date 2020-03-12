﻿// *****************************************************************
//    Copyright (c) Microsoft. All rights reserved.
//    This code is licensed under the Microsoft Public License.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
// *****************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBF.Algorithms.Assembly.Graph;
using MBF.Algorithms.Assembly.PaDeNA.Properties;

namespace MBF.Algorithms.Assembly.PaDeNA.Scaffold
{
    /// <summary>
    /// Performs Breadth First Search on Contig Overlap Graph
    /// using distance between contigs as constrain.
    /// </summary>
    public class TracePath : ITracePath
    {
        #region Field Variable

        /// <summary>
        /// Contig Overlap Graph
        /// </summary>
        private DeBruijnGraph _graph;

        /// <summary>
        /// Depth to which graph is traversed.
        /// </summary>
        private int _depth;

        /// <summary>
        /// Length of Kmer (indicates kmer -1 overlap between contigs).
        /// </summary>
        private int _kmerLength;

        #endregion

        #region ITracePath Members

        /// <summary>
        /// Performs Breadth First Search to traverse through graph to generate scaffold paths.
        /// </summary>
        /// <param name="graph">Contig Overlap Graph.</param>
        /// <param name="contigPairedReadMaps">InterContig Distances.</param>
        /// <param name="kmerLength">Length of Kmer</param>
        /// <param name="depth">Depth to which graph is searched.</param>
        /// <returns>List of paths/scaffold</returns>
        public IList<ScaffoldPath> FindPaths(
            DeBruijnGraph graph,
            ContigMatePairs contigPairedReadMaps,
            int kmerLength,
            int depth = 10)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }

            if (contigPairedReadMaps == null)
            {
                throw new ArgumentNullException("contigPairedReadMaps");
            }

            if (kmerLength <= 0)
            {
                throw new ArgumentException(Resource.KmerLength);
            }

            if (depth <= 0)
            {
                throw new ArgumentException(Resource.Depth);
            }

            _graph = graph;
            _kmerLength = kmerLength;
            _depth = depth;

            List<ScaffoldPath> scaffoldPaths = new List<ScaffoldPath>();
            Parallel.ForEach(_graph.Nodes, (DeBruijnNode node) =>
            {
                Dictionary<ISequence, IList<ValidMatePair>> contigPairedReadMap;
                if (contigPairedReadMaps.TryGetValue(graph.GetNodeSequence(node), out contigPairedReadMap))
                {
                    List<ScaffoldPath> scaffoldPath = TraverseGraph(node, contigPairedReadMap);
                    lock (scaffoldPaths)
                    {
                        scaffoldPaths.AddRange(scaffoldPath);
                    }
                }
            });

            return scaffoldPaths;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Performs Breadth First Search
        /// </summary>
        /// <param name="node">Start Node</param>
        /// <param name="contigPairedReadMap">Map of all contigs having valid 
        /// mate pairs with given node contig.</param>
        /// <returns>List of paths.</returns>
        private List<ScaffoldPath> TraverseGraph(
            DeBruijnNode node,
            Dictionary<ISequence,
            IList<ValidMatePair>> contigPairedReadMap)
        {
            Queue<Paths> search = new Queue<Paths>();
            List<Paths> paths = new List<Paths>();
            LeftExtension(
                new KeyValuePair<DeBruijnNode, DeBruijnEdge>(node, new DeBruijnEdge(false)),
                search,
                paths,
                null,
                contigPairedReadMap);
            RightExtension(
                new KeyValuePair<DeBruijnNode, DeBruijnEdge>(node, new DeBruijnEdge(true)),
                search,
                paths,
                null,
                contigPairedReadMap);
            Paths parentPath;
            while (search.Count != 0)
            {
                parentPath = search.Dequeue();
                if (parentPath.NodeOrientation)
                {
                    if (parentPath.CurrentNode.Value.IsSameOrientation)
                    {
                        RightExtension(
                            parentPath.CurrentNode,
                            search,
                            paths,
                            parentPath.FamilyTree,
                            contigPairedReadMap);
                    }
                    else
                    {
                        LeftExtension(
                            parentPath.CurrentNode,
                            search,
                            paths,
                            parentPath.FamilyTree,
                            contigPairedReadMap);
                    }
                }
                else if (parentPath.CurrentNode.Value.IsSameOrientation)
                {
                    LeftExtension(
                        parentPath.CurrentNode,
                        search,
                        paths,
                        parentPath.FamilyTree,
                        contigPairedReadMap);
                }
                else
                {
                    RightExtension(
                        parentPath.CurrentNode,
                        search,
                        paths,
                        parentPath.FamilyTree,
                        contigPairedReadMap);
                }
            }

            return new List<ScaffoldPath>(paths.Select(t => t.FamilyTree)); 
        }

        /// <summary>
        /// Add left extension of the nodes to queue.  
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <param name="search">Queue for BFS.</param>
        /// <param name="paths">List of paths</param>
        /// <param name="familyTree">nodes visited for construction of paths.</param>
        /// <param name="contigPairedReadMap">contig and valid mate pair map.</param>
        private void LeftExtension(
            KeyValuePair<DeBruijnNode, DeBruijnEdge> node,
            Queue<Paths> search,
            List<Paths> paths,
            ScaffoldPath familyTree,
            Dictionary<ISequence, IList<ValidMatePair>> contigPairedReadMap)
        {
            Paths childPath;
            if (node.Key.LeftExtensionNodes.Count > 0)
            {
                foreach (KeyValuePair<DeBruijnNode, DeBruijnEdge> child in node.Key.LeftExtensionNodes)
                {
                    childPath = new Paths();
                    childPath.CurrentNode = child;
                    if (familyTree == null)
                    {
                        childPath.FamilyTree.Add(node);
                    }
                    else
                    {
                        childPath.FamilyTree.AddRange(familyTree);
                        childPath.FamilyTree.Add(node);
                    }

                    childPath.NodeOrientation = false;
                    if (DistanceConstraint(childPath, contigPairedReadMap) &&
                        childPath.FamilyTree.Count < _depth && 
                        !contigPairedReadMap.All(
                        t => childPath.FamilyTree.Any(k => t.Key == _graph.GetNodeSequence(k.Key))))
                    {
                        search.Enqueue(childPath);
                    }
                    else
                    {
                        if(contigPairedReadMap.All(
                            t => childPath.FamilyTree.Any(k => t.Key == _graph.GetNodeSequence(k.Key))))
                        {
                            paths.Add(childPath);
                        }
                    }
                }
            }
            else
            {
                childPath = new Paths();
                if (familyTree == null)
                {
                    childPath.FamilyTree.Add(node);
                }
                else
                {
                    childPath.FamilyTree.AddRange(familyTree);
                    childPath.FamilyTree.Add(node);
                }

                if(contigPairedReadMap.All(
                    t => childPath.FamilyTree.Any(k => t.Key == _graph.GetNodeSequence(k.Key))))
                {
                    paths.Add(childPath);
                }
            }
        }

        /// <summary>
        /// Add right extension of the nodes to queue.
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <param name="search">Queue for BFS.</param>
        /// <param name="paths">List of paths</param>
        /// <param name="familyTree">nodes visited for construction of paths.</param>
        /// <param name="contigPairedReadMap">contig and valid mate pair map.</param>
        private void RightExtension(
            KeyValuePair<DeBruijnNode, DeBruijnEdge> node,
            Queue<Paths> search,
            List<Paths> paths,
            ScaffoldPath familyTree,
            Dictionary<ISequence, IList<ValidMatePair>> contigPairedReadMap)
        {
            Paths childPath;
            if (node.Key.RightExtensionNodes.Count > 0)
            {
                foreach (KeyValuePair<DeBruijnNode, DeBruijnEdge> child in node.Key.RightExtensionNodes)
                {
                    childPath = new Paths();
                    childPath.CurrentNode = child;
                    if (familyTree == null)
                    {
                        childPath.FamilyTree.Add(node);
                    }
                    else
                    {
                        childPath.FamilyTree.AddRange(familyTree);
                        childPath.FamilyTree.Add(node);
                    }

                    childPath.NodeOrientation = true;
                    if (DistanceConstraint(childPath, contigPairedReadMap) &&
                        childPath.FamilyTree.Count < _depth && 
                        !contigPairedReadMap.All(
                        t => childPath.FamilyTree.Any(k => t.Key == _graph.GetNodeSequence(k.Key))))
                    {
                        search.Enqueue(childPath);
                    }
                    else
                    {
                       if(contigPairedReadMap.All(
                            t => childPath.FamilyTree.Any(k => t.Key == _graph.GetNodeSequence(k.Key))))
                        {
                            paths.Add(childPath);
                        }
                    }
                }
            }
            else
            {
                childPath = new Paths();
                if (familyTree == null)
                {
                    childPath.FamilyTree.Add(node);
                }
                else
                {
                    childPath.FamilyTree.AddRange(familyTree);
                    childPath.FamilyTree.Add(node);
                }

               if(contigPairedReadMap.All(
                    t => childPath.FamilyTree.Any(k => t.Key == _graph.GetNodeSequence(k.Key))))
                {
                    paths.Add(childPath);
                }
            }
        }

        /// <summary>
        /// Apply Distance constrains on given two nodes.
        /// The distances between contigs are calculated using paired read information.
        /// </summary>
        /// <param name="childPath">Destination node.</param>
        /// <param name="contigPairedReadMaps">Map of contigs and paired reads.</param>
        /// <returns>Whether Distance between contig nodes lie in constraint or not.</returns>
        private bool DistanceConstraint(
            Paths childPath,
            Dictionary<ISequence, IList<ValidMatePair>> contigPairedReadMaps)
        {
            IList<ValidMatePair> map;
            if (contigPairedReadMaps.TryGetValue(_graph.GetNodeSequence(childPath.CurrentNode.Key), out map))
            {
                float pathlength = GetPathLength(childPath);
                if (childPath.CurrentNode.Value.IsSameOrientation)
                {
                    if ((map[0].DistanceBetweenContigs[0] -
                        (3 * map[0].StandardDeviation[0]) <= pathlength) &&
                        (pathlength <= map[0].DistanceBetweenContigs[0] +
                        (3 * map[0].StandardDeviation[0])))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((map[0].DistanceBetweenContigs[1] -
                         (3 * map[0].StandardDeviation[1]) <= pathlength) &&
                        (pathlength <= map[0].DistanceBetweenContigs[1] +
                    (3 * map[0].StandardDeviation[1])))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Get length of path traversed using BFS.
        /// </summary>
        /// <param name="childPath">Path travelled to reach destination node.</param>
        /// <returns>Distance beteen first and last contig node.</returns>
        private float GetPathLength(Paths childPath)
        {
            float distance = 0;
            for (int index = 1; index < childPath.FamilyTree.Count; index++)
            {
                distance += _graph.GetNodeSequence(childPath.FamilyTree[index].Key).Count - _kmerLength;
            }

            distance -= _kmerLength;
            return distance;
        }

        #endregion
    }

    #region Internal Classes

    /// <summary>
    /// Class stores information of path travelled while performing BFS.
    /// </summary>
    internal class Paths
    {
        #region Field Variable

        /// <summary>
        /// Path travelled
        /// </summary>
        private ScaffoldPath path = new ScaffoldPath();

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets value of current Node.
        /// </summary>
        public KeyValuePair<DeBruijnNode, DeBruijnEdge> CurrentNode { get; set; }

        /// <summary>
        /// Gets or sets value indicating orientation of current node.
        /// </summary>
        public bool NodeOrientation { get; set; }

        /// <summary>
        /// Gets the value of family tree/path traversed to reach to current node.
        /// </summary>
        public ScaffoldPath FamilyTree
        {
            get { return path; }
        }

        #endregion
    }

    #endregion
}