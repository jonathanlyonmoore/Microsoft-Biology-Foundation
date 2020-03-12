﻿// *****************************************************************
//    Copyright (c) Microsoft. All rights reserved.
//    This code is licensed under the Apache License, Version 2.0.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
// *****************************************************************

/****************************************************************************
 * ComparativeP1TestCases.cs
 * 
 *  This file contains the Comparative P1 test cases.
 * 
***************************************************************************/
using Bio;
using Bio.Algorithms.Assembly.Comparative;
using Bio.Algorithms.Alignment;
using Bio.Algorithms.Assembly.Padena.Scaffold;
using Bio.IO.FastA;
using Bio.TestAutomation.Util;
using Bio.Util.Logging;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Bio.TestAutomation.Algorithms.Assembly.Comparative
{
    /// <summary>
    /// Comparative P1 test cases
    /// </summary>
    [TestClass]
    public class ComparativeP1TestCases
    {
        #region Global Variables

        Utility utilityObj = new Utility(@"TestUtils\ComparativeTestData\ComparativeTestsConfig.xml");

        #endregion Global Variables

        #region Constructor

        /// <summary>
        /// Static constructor to open log and make other settings needed for test
        /// </summary>
        static ComparativeP1TestCases()
        {
            Trace.Set(Trace.SeqWarnings);
            if (!ApplicationLog.Ready)
            {
                ApplicationLog.Open("mbf.automation.log");
            }
        }

        #endregion Constructor

        #region Test cases.

        # region Steps 1-5

        # region With Errors.

        /// <summary>
        /// Validate Assemble().
        /// Inputs(references and reads) having one line sequences with reads having errors.
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [TestCategory("Priority1")]
        public void ValidateAssembleWithErrorsOnMediumSizeDna()
        {
            ValidateComparativeAssembleMethod(Constants.SequenceWithErrorsReadsNode, false);
        }

        /// <summary>
        /// Validate Assemble().
        /// Inputs(references and reads) having large sequences, with non paired  reads having errors.
        /// Source for test data: \\er-data\MBF\Testdata\E_coli_k12_mg1655\Reads
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [TestCategory("Priority1")]
        public void ValidateAssembleWithEColiDataHavingErrors()
        {
            ValidateComparativeAssembleMethod(Constants.EcoliDataWithErrorsNode, true);
        }

        /// <summary>
        /// Validate Assemble().
        /// Inputs(references and reads) having large sequences with nucleotides added to reads.
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [TestCategory("Priority1")]
        public void ValidateAssembleWithAddedNucloetides()
        {
            ValidateComparativeAssembleMethod(Constants.LargeSequenceWithAddedReadsNode, false);
        }

        /// <summary>
        /// Validate Assemble().
        /// Inputs(references and reads) having large sequences with nucleotides deleted from the reads.
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [TestCategory("Priority1")]
        public void ValidateAssembleWithDeletedNucleotide()
        {
            ValidateComparativeAssembleMethod(Constants.LargeSequenceWithDeletedReadsNode, false);
        }


        # endregion With Errors.

        # region Without Errors

        /// <summary>
        /// Validate Assemble().
        /// Inputs(references and reads) having E-Coli data, with non paired reads having zero errors.
        /// Source for test data: \\er-data\MBF\Testdata\E_coli_k12_mg1655\Reads
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [TestCategory("Priority1")]
        public void ValidateAssembleWithZeroErrorsUsingEcoliAndNonPairedReads()
        {
            ValidateComparativeAssembleMethod(Constants.EcoliDataWithZeroErrorsNodeNonPaired, true);
        }

        /// <summary>
        /// Validate Assemble().
        /// Inputs(references and reads) having E-Coli data, with paired reads having zero errors.
        /// Source for Ref file: \\er-data\MBF\Testdata\E_coli_k12_mg1655\Reads
        /// Reads are generated using the command "SeqGen.exe -pairinsertlength 0 -coverage 1 
        /// -length 40 -Inserts 0.00 -Deletes 0.00 EColi-NC_000913-Ref.bd.fasta"        
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [TestCategory("Priority1")]
        public void ValidateAssembleWithZeroErrorsPairedReadsUsingEcoli()
        {
            ValidateComparativeAssembleMethod(Constants.EcoliDataWithZeroErrorsPairedNode, true);
        }

        #endregion Without Errors

        # endregion Steps 1-5

        #endregion Test cases.

        # region Supporting methods

        /// <summary>
        /// Validates Assemble method .Step 1-5.        
        /// </summary>
        /// <param name="nodeName">Parent Node name in Xml</param>
        /// <param name="isFilePath">Sequence location.</param>
        public void ValidateComparativeAssembleMethod(string nodeName, bool isEcOli)
        {
            ComparativeGenomeAssembler assemble = new ComparativeGenomeAssembler();
            List<ISequence> referenceSeqList = new List<ISequence>();
            List<ISequence> readSeqList = new List<ISequence>();
            string expectedSequence = null;
            string LengthOfMUM = utilityObj.xmlUtil.GetTextValue(nodeName,
                     Constants.MUMLengthNode);
            string kmerLength = utilityObj.xmlUtil.GetTextValue(nodeName,
                     Constants.KmerLengthNode);

            // Gets the reference sequence from the FastA file
            string filePath = utilityObj.xmlUtil.GetTextValue(nodeName,
                Constants.FilePathNode1);

            Assert.IsNotNull(filePath);
            ApplicationLog.WriteLine(string.Format((IFormatProvider)null,
                "Comparative P1 : Successfully validated the File Path '{0}'.", filePath));

            using (FastAParser parser = new FastAParser(filePath))
            {
                IEnumerable<ISequence> referenceList = parser.Parse();

                foreach (ISequence seq in referenceList)
                {
                    referenceSeqList.Add(seq);
                }
            }

            //Get the reads from configurtion file .
            readSeqList = GetReads(nodeName);
            assemble.LengthOfMum = int.Parse(LengthOfMUM);
            assemble.KmerLength = int.Parse(kmerLength);
            IEnumerable<ISequence> outputAssemble = assemble.Assemble(referenceSeqList, readSeqList);

            if (isEcOli)
            {
                expectedSequence = utilityObj.xmlUtil.GetFileTextValue(nodeName,
                                    Constants.ExpectedSequenceNode);
            }
            else
            {
                expectedSequence = utilityObj.xmlUtil.GetTextValue(nodeName,
                                    Constants.ExpectedSequenceNode);
            }

            StringBuilder longOutput = new StringBuilder();
            IEnumerable<string> outputStrings = outputAssemble.Select(a => new string(a.Select(b => (char)b).ToArray())).OrderBy(c => c);
            foreach (string x in outputStrings)
                longOutput.Append(x);

            Assert.AreEqual(expectedSequence.ToString().ToUpperInvariant(), longOutput.ToString().ToUpperInvariant());
        }

        /// <summary>
        /// Method to get the reads from file/xml.
        /// </summary>
        /// <param name="nodeName">Parent node in Xml</param>
        /// <param name="isFilePath">Represents sequence is in a file or not</param>
        /// <returns></returns>
        public List<ISequence> GetReads(string nodeName)
        {
            List<ISequence> readSeqList = new List<ISequence>();

            // Gets the reads from the FastA file
            string readFilePath = utilityObj.xmlUtil.GetTextValue(nodeName,
                Constants.FilePathNode2);

            Assert.IsNotNull(readFilePath);
            ApplicationLog.WriteLine(string.Format((IFormatProvider)null,
                "Comparative P1 : Successfully validated the File Path '{0}'.", readFilePath));

            using (FastAParser queryParser = new FastAParser(readFilePath))
            {
                IEnumerable<ISequence> querySeqList = queryParser.Parse();

                foreach (ISequence seq in querySeqList)
                {
                    readSeqList.Add(seq);
                }
            }
            return readSeqList;
        }

        /// TODO: This code would be used after proper paired read information is available for E-coli
        ///// <summary>
        ///// Will get expected Sequence ny reading from E-Coli file.
        ///// Input:FilePath
        ///// </summary>
        ///// <returns>Sequence</returns>
        //public string GetExpectedSequenceForEcoli(string filepath)
        //{
        //    string expectedSequence = string.Empty;
        //    string currLine = string.Empty;

        //    using (StreamReader reader = new StreamReader(filepath))
        //    {
        //        do
        //        {
        //            currLine = reader.ReadLine();
        //            if (!(currLine == null || currLine.StartsWith(">", StringComparison.OrdinalIgnoreCase) || currLine == ""))
        //            {
        //                expectedSequence += currLine;
        //            }
        //        }
        //        while (!(currLine == null));
        //    }

        //    return expectedSequence;
        //}

        # endregion Supporting methods
    }
}