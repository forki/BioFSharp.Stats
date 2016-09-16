namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("BioFSharp.Stats")>]
[<assembly: AssemblyProductAttribute("BioFSharp.Stats")>]
[<assembly: AssemblyDescriptionAttribute("FsharpBio.Stats aims to be a user-friendly library for statistics used in bioinformatics written in F#.")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
    let [<Literal>] InformationalVersion = "1.0"
