﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.MUMmer;
using Bio.Registration;

namespace Bio.Algorithms.Alignment
{
    /// <summary>
    /// SequenceAligners class is an abstraction class which provides instances
    /// and lists of all Aligners currently supported by Bio. 
    /// </summary>
    public static class SequenceAligners
    {
        /// <summary>
        /// A singleton instance of SmithWatermanAligner class which implements
        /// the SmithWaterman algorithm for partial alignment
        /// </summary>
        private static SmithWatermanAligner smithAlign = new SmithWatermanAligner();

        /// <summary>
        /// A singleton instance of NeedlemanWunschAligner class which implements
        /// the NeedlemanWunsch algorithm for global alignment.
        /// </summary>
        private static NeedlemanWunschAligner needlemanAlign = new NeedlemanWunschAligner();

        /// <summary>
        /// A singleton instance of MUMmer class which implements
        /// mummer alignment algorithm.
        /// </summary>
        private static MUMmerAligner mummerAlign = new MUMmerAligner();

        /// <summary>
        /// A singleton instance of NUCmer class which implements
        /// NUCmer alignment algorithm.
        /// </summary>
        private static NucmerPairwiseAligner nucmerAlign = new NucmerPairwiseAligner();

        /// <summary>
        /// List of supported sequence aligners.
        /// </summary>
        private static readonly List<ISequenceAligner> all = new List<ISequenceAligner>() 
        { 
            smithAlign, 
            needlemanAlign,
            mummerAlign,
            nucmerAlign
        };

        /// <summary>
        /// Initializes static members of the SequenceAligners class.
        /// Static constructor
        /// </summary>
        static SequenceAligners()
        {
            // Get the registered aligners
            IEnumerable<ISequenceAligner> registeredAligners = GetAligners();

            if (null != registeredAligners)
            {
                foreach (ISequenceAligner aligner in registeredAligners.Where(
                    aligner => aligner != null && all.All(sa => string.Compare(sa.Name, aligner.Name, StringComparison.OrdinalIgnoreCase) != 0)))
                {
                    all.Add(aligner);
                }
            }
        }

        /// <summary>
        /// Gets an instance of SmithWatermanAligner class which implements
        /// the SmithWaterman algorithm for partial alignment
        /// </summary>
        public static SmithWatermanAligner SmithWaterman
        {
            get
            {
                return smithAlign;
            }
        }

        /// <summary>
        /// Gets an instance of NeedlemanWunschAligner class which implements
        /// the NeedlemanWunsch algorithm for global alignment.
        /// </summary>
        public static NeedlemanWunschAligner NeedlemanWunsch
        {
            get
            {
                return needlemanAlign;
            }
        }

        /// <summary>
        /// Gets an instance of MUMmer3 class which implements
        /// the MUMmer algorithm for partial alignment
        /// </summary>
        public static MUMmerAligner MUMmer
        {
            get
            {
                return mummerAlign;
            }
        }

        /// <summary>
        /// Gets an instance of NUCmer3 class which implements
        /// the NUCmer algorithm for alignment
        /// </summary>
        public static NucmerPairwiseAligner NUCmer
        {
            get
            {
                return nucmerAlign;
            }
        }

        /// <summary>
        /// Gets the list of all aligners which is supported by the framework.
        /// </summary>
        public static IList<ISequenceAligner> All
        {
            get
            {
                return all.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets all registered aligners in core folder and addins (optional) folders
        /// </summary>
        /// <returns>List of registered aligners</returns>
        private static IEnumerable<ISequenceAligner> GetAligners()
        {
            IList<ISequenceAligner> registeredAligners = new List<ISequenceAligner>();
            IList<ISequenceAligner> addInAligners = RegisteredAddIn.GetComposedInstancesFromAssemblyPath<ISequenceAligner>(
                "NetBioSequenceAlignersExport", RegisteredAddIn.AddinFolderPath, RegisteredAddIn.DLLFilter);
            if (null != addInAligners && addInAligners.Count > 0)
            {
                foreach (ISequenceAligner aligner in addInAligners.Where(
                    aligner => aligner != null && registeredAligners.All(sa => string.Compare(sa.Name, aligner.Name, StringComparison.OrdinalIgnoreCase) != 0)))
                {
                    registeredAligners.Add(aligner);
                }
            }
            return registeredAligners;
        }
    }
}
