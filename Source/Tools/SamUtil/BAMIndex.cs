﻿using System;
using Bio.IO.BAM;
using SamUtil.Properties;

namespace SamUtil
{
    /// <summary>
    /// Class implementing index command of SAM Utility.
    /// </summary>
    public class Index
    {
        #region Public Fields

        /// <summary>
        /// Input file name.
        /// </summary>
        public string InputFilename;

        /// <summary>
        /// Usage(Help)
        /// </summary>
        public bool Help;

        /// <summary>
        /// Output file name
        /// </summary>
        public string OutputFilename;

        #endregion

        #region Private Fields
        /// <summary>
        /// whether output file name is auto genertaed.
        /// </summary>
        private bool autoGeneratedOutputFilename = false;
        #endregion

        #region Public Methods

        /// <summary>
        /// Public method implementing Index method of SAM tool.
        /// SAMUtil.exe index in.bam (output file: in.bam.bai)
        /// </summary>
        public void GenerateIndexFile()
        {
            if (string.IsNullOrEmpty(InputFilename))
            {
                throw new InvalidOperationException(Resources.IndexHelp);
            }
           
            try
            {
                if (string.IsNullOrEmpty(OutputFilename))
                {
                    OutputFilename = InputFilename + Properties.Resources.BAM_INDEXFILEEXTENSION;
                    autoGeneratedOutputFilename = true;
                }

                BAMFormatter.CreateBAMIndexFile(InputFilename, OutputFilename);

                if (autoGeneratedOutputFilename)
                {
                    Console.WriteLine(Properties.Resources.SuccessMessageWithOutputFileName, OutputFilename);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resources.InvalidBAMFile, ex);
            }
        }

        #endregion
    }
}
