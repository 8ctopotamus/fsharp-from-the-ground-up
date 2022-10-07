open System
open System.IO

let summarize filePath =
  let rows = File.ReadAllLines filePath
  let studentCount = (rows |> Array.length) - 1
  for row in rows do
    printfn "%i %s" studentCount row

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