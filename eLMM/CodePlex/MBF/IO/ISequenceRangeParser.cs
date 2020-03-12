//*********************************************************
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
//
//
//
//
//
//*********************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using Bio;

namespace Bio.IO
{
    /// <summary>
    /// The interface defining the methods for parsing ISequenceRange
    /// objects from files or readers.
    /// </summary>
    public interface ISequenceRangeParser
    {
        /// <summary>
        /// Parse a set of ISequenceRange objects from a file.
        /// </summary>
        IList<ISequenceRange> ParseRange(string fileName);

        /// <summary>
        /// Parse a set of ISequenceRange objects into a SequenceRange
        /// grouping from a file.
        /// </summary>
        SequenceRangeGrouping ParseRangeGrouping(string fileName);

        /// <summary>
        /// Parse a set of ISequenceRange objects from a reader.
        /// </summary>
        IList<ISequenceRange> ParseRange(TextReader reader);

        /// <summary>
        /// Parse a set of ISequenceRange objects into a SequenceRange
        /// grouping from a reader.
        /// </summary>
        SequenceRangeGrouping ParseRangeGrouping(TextReader reader);

        /// <summary>
        /// Gets the name of the sequence range parser being
        /// implemented. This is intended to give the
        /// developer some information of the parser type.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the description of the sequence range parser being
        /// implemented. This is intended to give the
        /// developer some information of the parser.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the file extensions that the parser implementation
        /// will support.
        /// </summary>
        string FileTypes { get; }
    }
}