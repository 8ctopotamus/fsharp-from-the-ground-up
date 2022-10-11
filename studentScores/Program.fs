open System
open System.IO

type Student = 
  {
    Name : String
    Id : string
    MeanScore : float
    MinScore : float
    MaxScore : float
  }

module Student = 
  let fromString (s : string) =
    let elements = s.Split('\t')
    let id = elements.[0]
    let name = elements.[1]
    let scores = 
      elements
      |> Array.skip 2
      |> Array.map float
      |> Array.sort 
    let meanScore = scores |> Array.average
    let minScore = scores |> Array.min
    let maxScore = scores |> Array.max
    {
      Name = name
      Id  = id
      MeanScore = meanScore
      MinScore  = minScore
      MaxScore = maxScore
    }

  let printMeanScore (student : Student) =
    printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Name student.Id student.MeanScore student.MinScore student.MaxScore

let summarize filePath =
  let rows = File.ReadAllLines filePath
  let studentCount = (rows |> Array.length) - 1
  rows
  |> Array.skip 1
  |> Array.map Student.fromString
  |> Array.sortBy (fun student -> student.Name)
  |> Array.iter Student.printMeanScore

[<EntryPoint>]
let main argv = 
  if argv.Length = 1 then
    let filePath = argv.[0]
    if File.Exists(filePath) then
      printfn "Processing %s" filePath
      summarize filePath
      0
    else
      printfn "File %s does not exist" filePath
      2
  else
    printfn "Please specify a file"
    1