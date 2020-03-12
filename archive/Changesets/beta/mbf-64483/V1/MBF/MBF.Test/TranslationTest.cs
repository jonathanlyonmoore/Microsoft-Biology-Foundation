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
using System.Text;

using NUnit.Framework;
using MBF.Util;
using MBF.Util.Logging;
using MBF.Algorithms.Translation;

namespace MBF.Test
{
    /// <summary>
    /// Test the Translation classes.
    /// </summary>
    [TestFixture]
    public class TranslationTest
    {
        /// <summary>
        /// Static constructor to open log and make other settings needed for test
        /// </summary>
        static TranslationTest()
        {
            Trace.Set(Trace.SeqWarnings);
            if (!ApplicationLog.Ready)
            {
                ApplicationLog.Open("mbf.test.log");
            }
        }

        /// <summary>
        /// Test the Complementation class.
        /// </summary>
        [Test]
        public void TestComplementation()
        {
            ISequence seq = new Sequence(Alphabets.DNA, "GATACCCAAGGT");
            ISequence complement = Complementation.Complement(seq);
            Assert.AreEqual("CTATGGGTTCCA", complement.ToString());

            ISequence reverseComplement = Complementation.ReverseComplement(seq);
            Assert.AreEqual("ACCTTGGGTATC", reverseComplement.ToString());
        }

        /// <summary>
        /// Test the Transcription class.
        /// </summary>
        [Test]
        public void TestTranscription()
        {
            ISequence seq = new Sequence(Alphabets.DNA, "ATGGCG");
            ISequence transcript = Transcription.Transcribe(seq);
            Assert.AreEqual("UACCGC", transcript.ToString());
            Assert.AreEqual(Alphabets.RNA, transcript.Alphabet);

            ISequence reverseTranscript = Transcription.ReverseTranscribe(transcript);
            Assert.AreEqual("ATGGCG", reverseTranscript.ToString());
            Assert.AreEqual(Alphabets.DNA, reverseTranscript.Alphabet);
        }
    }
}