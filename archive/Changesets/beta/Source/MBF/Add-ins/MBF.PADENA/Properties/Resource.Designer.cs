﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MBF.Algorithms.Assembly.PaDeNA.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MBF.Algorithms.Assembly.PaDeNA.Properties.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to At least one sequence should not contain Gap/Ambiguous character.
        /// </summary>
        internal static string AmbiguousCharacter {
            get {
                return ResourceManager.GetString("AmbiguousCharacter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot Assemble RNA or Protein Sequences .
        /// </summary>
        internal static string CannotAssembleSequenceType {
            get {
                return ResourceManager.GetString("CannotAssembleSequenceType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DanglingLinksPurger.
        /// </summary>
        internal static string DanglingLinksPurger {
            get {
                return ResourceManager.GetString("DanglingLinksPurger", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error correction module by removal of dangling links in graph.
        /// </summary>
        internal static string DanglingLinksPurgerDescription {
            get {
                return ResourceManager.GetString("DanglingLinksPurgerDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Depth cannot be less than or equal to 0.
        /// </summary>
        internal static string Depth {
            get {
                return ResourceManager.GetString("Depth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicate read found. Id:{0}.
        /// </summary>
        internal static string DuplicatingReadIds {
            get {
                return ResourceManager.GetString("DuplicatingReadIds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Kmer length must be less than the length of the shortest sequence, and should be greater than half the length of the longest sequence..
        /// </summary>
        internal static string InappropriateKmerLength {
            get {
                return ResourceManager.GetString("InappropriateKmerLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One of the sequences in list is null. All sequences in input list must be valid sequences..
        /// </summary>
        internal static string InputSequenceCannotBeNull {
            get {
                return ResourceManager.GetString("InputSequenceCannotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Kmer length cannot be less than or equal to 0.
        /// </summary>
        internal static string KmerLength {
            get {
                return ResourceManager.GetString("KmerLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Redundancy value cannot be negative.
        /// </summary>
        internal static string NegativeRedundancy {
            get {
                return ResourceManager.GetString("NegativeRedundancy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Contig Builder cannot be null.
        /// </summary>
        internal static string NullContigBuilder {
            get {
                return ResourceManager.GetString("NullContigBuilder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PaDeNA.
        /// </summary>
        internal static string PaDeNA {
            get {
                return ResourceManager.GetString("PaDeNA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Implements parallel de-novo assembly using De-bruijn graph.
        /// </summary>
        internal static string PaDeNADescription {
            get {
                return ResourceManager.GetString("PaDeNADescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Paired Read Data.
        /// </summary>
        internal static string PairedReadException {
            get {
                return ResourceManager.GetString("PairedReadException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RedundantPathsPurger.
        /// </summary>
        internal static string RedundantPathsPurger {
            get {
                return ResourceManager.GetString("RedundantPathsPurger", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Graph error correction by removal of redundant paths.
        /// </summary>
        internal static string RedundantPathsPurgerDescription {
            get {
                return ResourceManager.GetString("RedundantPathsPurgerDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Simple path based contig builder.
        /// </summary>
        internal static string SimplePathContigBuilder {
            get {
                return ResourceManager.GetString("SimplePathContigBuilder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Builds contigs from simple paths in the de bruijn graph.
        /// </summary>
        internal static string SimplePathContigBuilderDescription {
            get {
                return ResourceManager.GetString("SimplePathContigBuilderDescription", resourceCulture);
            }
        }
    }
}