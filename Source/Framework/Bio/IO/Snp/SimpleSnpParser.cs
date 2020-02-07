﻿using System.ComponentModel.Composition;

namespace Bio.IO.Snp
{
    /// <summary>
    /// Simple SNP Parser that uses an XsvSnpReader for parsing files with 
    /// chromosome number, position, allele 1 and allele 2 in tab separated 
    /// columns into sequences with the first allele.
    /// </summary>
    [PartNotDiscoverable]
    public class SimpleSnpParser : SnpParser
    {
        #region Constructor
        /// <summary>
        /// Creates a SimpleSnpParser which generates parsed sequences that use the the 
        /// given alphabet and encoding.
        /// NOTE: Given that this parses Snps, should we always use the DnaAlphabet?
        /// </summary>
        public SimpleSnpParser(IAlphabet alphabet)
            : base(alphabet)
        {
        }

        /// <summary>
        /// Constructor SimpleSnpParser.
        /// </summary>
        /// <param name="filePath">The file path to be parsed.</param>
        public SimpleSnpParser(string filePath)
            : base(filePath)
        {
            Alphabet = AmbiguousDnaAlphabet.Instance;
        }
        
        #endregion Constructor

        #region Overrides of SnpParser

        /// <summary>
        /// Gets the name of the parser. 
        /// </summary>
        public override string Name
        {
            get
            {
                return Properties.Resource.SIMPLE_SNP_NAME;
            }
        }

        /// <summary>
        /// Gets the description of the parser.
        /// </summary>
        public override string Description
        {
            get
            {
                return Properties.Resource.SIMPLE_SNP_DESCRIPTION;
            }
        }

        /// <summary>
        /// Gives the supported file types.
        /// </summary>
        public override string SupportedFileTypes
        {
            get { return Properties.Resource.SIMPLE_SNP_FILEEXTENSION; }
        }

        #endregion
    }
}
