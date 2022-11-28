namespace StudentScores

module SchoolCodes =

  open System.IO
  // open System.Collections.Generic

  let load (filePath : string) =
    File.ReadAllLines filePath
      |> Seq.skip 1
      |> Seq.map (fun row -> 
          let elements = row.Split('\t')
          let id = elements.[0]
          let name = elements.[1]
          id, name )
      |> Map.ofSeq
      |> Map.add "*" "(External)"