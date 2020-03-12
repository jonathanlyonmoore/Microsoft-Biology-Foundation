﻿// *********************************************************
// 
//     Copyright (c) Microsoft. All rights reserved.
//     This code is licensed under the Apache License, Version 2.0.
//     THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//     ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//     IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//     PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
// 
// *********************************************************
using System;

namespace Bio
{
    /// <summary>
    /// A FastQFormatType specifies the format of quality scores.
    /// </summary>
    public enum FastQFormatType
    {
        /// <summary>
        /// Illumina 1.3 FastQFormatType.
        /// This type uses Phred quality scores ranges from 0 to 62 and are encoded using ASCII 64 to 126.
        /// </summary>
        Illumina = 0,

        /// <summary>
        /// Solexa/Illumina 1.0 FastQFormatType.
        /// This type uses Solexa / Illumina quality scores ranges from -5 to 62 and are encoded using ASCII 59 to 126.
        /// </summary>
        Solexa,

        /// <summary>
        /// Sanger FastQFormatType.
        /// This type uses Phred quality scores ranges from 0 to 93 and are encoded using ASCII 33 to 126 
        /// </summary>
        Sanger
    }
}