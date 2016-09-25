(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"
#r "../../packages/build/FSharp.Plotly/lib/net40/Fsharp.Plotly.dll"
open FSharp.Plotly
(**
Machine learning
================
Machine learning is a subfield of computer science that evolved from the study of pattern recognition and computational learning theory in artificial intelligence. In 1959, Arthur Samuel defined machine learning as a "Field of study that gives computers the ability to learn without being explicitly programmed".

*)
#r "FSharp.Care.dll"
#r "FSharp.Care.IO.dll"

#r "BioFSharp.Stats.dll"
open BioFSharp.Stats



open FSharp.Care.IO
open FSharp.Care.IO.SchemaReader
open FSharp.Care.IO.SchemaReader.Csv
open FSharp.Care.IO.SchemaReader.Attribute

// ##################################################################
// Examples: Csv-reader reads iris data set
type irisItem = 
    { [<FieldAttribute("Sepal length")>] SepalLength : float
      [<FieldAttribute("Sepal width")>] SepalWidth : float
      [<FieldAttribute("Petal length")>] PetalLength : float
      [<FieldAttribute("Petal width")>] PetalWidth : float
      [<FieldAttribute("Species")>] Species : string }



//let _         = IO.setWorkingDirectory __SOURCE_DIRECTORY__
let path = "./Examples/Data/irisData.csv" //....
let reader = new CsvReader<irisItem>(schemaMode = SchemaMode.Fill)
let hasHeader = true
let separator = ','
let data = reader.ReadFile(path, separator, hasHeader)

(*** define-output:pie1 ***)
Chart.Point([1;2;3],[1;2;3],Name="scattern")
(*** include-it:pie1 ***)



(**
BioFSharp ML module 
--------------------
Principal component analysis of the iris data set and visual inspection of the result.
*)
open BioFSharp.Stats.ML
open BioFSharp.Stats.ML.Unsupervised


let adjCenter = PCA.toAdjustCenter irisFeaturesMatrix
let irisPCA = PCA.compute adjCenter irisFeaturesMatrix
let irisDataPCA = PCA.transform adjCenter irisPCA irisFeaturesMatrix
let irisrev = PCA.revert adjCenter irisPCA irisDataPCA




