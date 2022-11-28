namespace StudentScores

module SchoolCodes =

  open System.IO
  open System.Collections.Generic

  let load (filePath : string) =
    // let pairs = 
    //   File.ReadAllLines filePath
    //   |> Seq.skip 1
    //   |> Seq.map (fun row -> 
    //       let elements = row.Split('\t')
    //       let id = elements.[0] |> int
    //       let name = elements.[1]
    //       KeyValuePair.Create(id, name) )
    // // new Dictionary<int, string>(pairs)
    // new Dictionary<_, _>(pairs)
    File.ReadAllLines filePath
      |> Seq.skip 1
      |> Seq.map (fun row -> 
          let elements = row.Split('\t')
          let id = elements.[0] |> int
          let name = elements.[1]
          id, name )
      |> dict 