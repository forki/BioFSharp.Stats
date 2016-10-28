(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"

(**
Introducing your project
========================

Say more

*)
#r "BioFSharp.Stats.dll"
open BioFSharp.Stats


let t  = [|-4. ..(8.0/500.).. 4.|]
let y  = t |> Array.map (fun t -> (-t**2.) + MathNet.Numerics.Distributions.Normal.WithMeanStdDev(0., 0.5).Sample() )
let y' = t |> Array.map (fun t -> (-t**2.))


let ysg = Signal.savitzky_golay  31 4 0 1 y

// [
//     Chart.Point(Seq.zip t y, Name="data with noise");
//     Chart.Point(Seq.zip t y', Name="data without noise");
//      Chart.Point(Seq.zip t ysg, Name="data sg")
// ]
// |> Chart.Combine