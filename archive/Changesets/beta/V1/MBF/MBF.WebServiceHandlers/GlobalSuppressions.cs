// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project. 
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc. 
//
// To add a suppression to this file, right-click the message in the 
// Error List, point to "Suppress Message(s)", and click 
// "In Project Suppression File". 
// You do not need to add suppressions to this file manually. 

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1824:MarkAssembliesWithNeutralResourcesLanguage")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.AzureBlastHandler.#CancelRequest(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_blastClient", Scope = "member", Target = "MBF.Web.Blast.AzureBlastHandler.#Dispose(System.Boolean)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.Blast.AzureBlastHandler.#FetchResultsSync(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.AzureBlastHandler.#FetchResultsSync(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.AzureBlastHandler.#InitializeBlastClient()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.Blast.AzureBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.AzureBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.AzureBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.AzureBlastHandler.#SubmitRequest(MBF.ISequence,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.Blast.EbiWuBlastHandler.#FetchResultsSync(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.EbiWuBlastHandler.#FetchResultsSync(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.EbiWuBlastHandler.#GetResult(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.Blast.EbiWuBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.EbiWuBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.EbiWuBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.EbiWuBlastHandler.#SubmitRequest(MBF.ISequence,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "MBF.Web.Blast.EbiWuBlastHandler.#ValidateParameters(MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#FetchResultsSync(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#FetchResultsSync(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#GetResult(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#GetResult(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#SubmitRequest(MBF.ISequence,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#SubmitRequest(MBF.ISequence,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Scope = "member", Target = "MBF.Web.Blast.NCBIBlastHandler.#ValidateParameters(MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#CancelRequest(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#convertRequestId(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#FetchResultsSync(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#FetchResultsSync(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#SubmitRequest(System.Collections.Generic.IList`1<MBF.ISequence>,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "BioHPCwebsvcClient.BioHPCClient.#DownloadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "BioHPCwebsvcClient.BioHPCClient.#UploadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#SubmitRequest(System.Collections.Generic.IList`1<MBF.ISequence>,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#SubmitRequest(System.Collections.Generic.IList`1<MBF.ISequence>,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "BioHPCwebsvcClient.BioHPCClient.#DownloadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "BioHPCwebsvcClient.BioHPCClient.#UploadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object,System.Object)", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#FetchResultsSync(System.String,MBF.Web.Blast.BlastParameters)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object,System.Object)", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#ProcessRequestThread(System.Object,System.ComponentModel.DoWorkEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int32.ToString", Scope = "member", Target = "BioHPCwebsvcClient.BioHPCClient.#DownloadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int64.ToString", Scope = "member", Target = "BioHPCwebsvcClient.BioHPCClient.#DownloadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Scope = "member", Target = "BioHPCwebsvcClient.BioHPCClient.#UploadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int32.ToString", Scope = "member", Target = "BioHPCwebsvcClient.BioHPCClient.#UploadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int64.ToString", Scope = "member", Target = "BioHPCwebsvcClient.BioHPCClient.#UploadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1304:SpecifyCultureInfo", MessageId = "System.String.ToLower", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#ValidateParameters(MBF.Web.Blast.BlastParameters,BioHPCwebsvcClient.AppInputData)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#ConvertRequestId(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.BioHPC.BioHPCClient.#DownloadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "MBF.Web.BioHPC.BioHPCClient.#DownloadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "MBF.Web.BioHPC.BioHPCClient.#UploadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1304:SpecifyCultureInfo", MessageId = "System.String.ToLower", Scope = "member", Target = "MBF.Web.Blast.BioHPCBlastHandler.#ValidateParameters(MBF.Web.Blast.BlastParameters,MBF.Web.BioHPC.AppInputData)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Scope = "member", Target = "MBF.Web.BioHPC.BioHPCClient.#UploadFile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "MBF.Web.BioHPC.BioHPCClient.#UploadFile(System.String,System.String,System.String,System.String)")]