open System
open System.IO

module Float = 
  let tryFromString (s : string) : float option =
    if s = "N/A" then
      None
    else 
      Some (float s)

  let fromStringOrDefault d s : float=
    s
    |> tryFromString
    |> Option.defaultValue d

type Student = 
  {
    Surname : String
    GivenName: String
    Id : string
    MeanScore : float
    MinScore : float
    MaxScore : float
  }

module Student = 

  let namePart (i: int) (s : string) = 
    let elements = s.Split(',')
    elements.[i].Trim()

  let fromString (s : string) =
    let elements = s.Split('\t')
    let id = elements.[0]
    let name = elements.[1]
    let given = namePart 0 name
    let sur = namePart 1 name
    let scores = 
      elements
      |> Array.skip 2
      |> Array.map (Float.fromStringOrDefault 50.)
      // |> Array.sort 
    let meanScore = scores |> Array.average
    let minScore = scores |> Array.min
    let maxScore = scores |> Array.max
    {
      Surname = sur
      GivenName = given
      Id = id
      MeanScore = meanScore
      MinScore  = minScore
      MaxScore = maxScore
    }

  let printMeanScore (student : Student) =
    printfn "%s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Surname student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore

let summarize filePath =
  let rows = File.ReadAllLines filePath
  let studentCount = (rows |> Array.length) - 1
  rows
  |> Array.skip 1
  |> Array.map Student.fromString
  |> Array.sortBy (fun student -> student.GivenName)
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