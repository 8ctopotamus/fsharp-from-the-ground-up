open System
open System.IO

let printMeanScore (row: string) =
  let elements = row.Split('\t')
  let id = elements.[0]
  let name = elements.[1]
  let meanScore = 
    elements
    |> Array.skip 2
    |> Array.map float
    |> Array.average
  printfn "%s\t%s\t%0.1f" name id meanScore

let summarize filePath =
  let rows = File.ReadAllLines filePath
  let studentCount = (rows |> Array.length) - 1
  rows
  |> Array.skip 1
  |> Array.iter printMeanScore

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