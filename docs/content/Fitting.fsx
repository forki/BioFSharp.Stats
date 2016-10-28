(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"
#r "../../packages/build/FSharp.Plotly/lib/net40/Fsharp.Plotly.dll"
open FSharp.Plotly
(**
Introducing your project
========================

Say more

*)

#r "MathNet.Numerics.dll"
#r "MathNet.Numerics.FSharp.dll"
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra
open MathNet.Numerics.LinearAlgebra.Double


#r "BioFSharp.Stats.dll"
open BioFSharp.Stats
open BioFSharp.Stats.Fitting




(**
Linear Regression
-----------------
*)


// Test versus http://www.cyclismo.org/tutorial/R/linearLeastSquares.html
let xVector = vector [2000.;   2001.;  2002.;  2003.;   2004.;]
let yVector = vector [9.34;   8.50;  7.62;  6.93;  6.60;]

let coeff   = Regression.Linear.coefficient xVector yVector
let fit     = Regression.Linear.fit coeff
let regLine = xVector |> Vector.map fit



let summary = Regression.calulcateSumOfSquares fit xVector yVector

let rsquared = Regression.calulcateDetermination summary

let sigIntercept = Regression.ttestIntercept coeff.[0] summary
let sigSlope     = Regression.ttestSlope coeff.[1] summary


let anova = Regression.Linear.calculateANOVA coeff xVector yVector


let aic = Regression.calcAIC 2. summary.Count summary.Error
let bic = Regression.calcBIC 2. summary.Count summary.Error

Regression.getResiduals fit xVector yVector
Regression.calculateSSE fit xVector yVector

(*** define-output:regression1 ***)
[
    Chart.Point(Seq.zip xVector yVector,Name="data points");
    Chart.Line(Seq.zip xVector regLine,Name ="regression")
]
|> Chart.Combine
(*** include-it:regression1 ***)







