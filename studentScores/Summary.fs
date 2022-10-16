namespace StudentScores

module Summary = 

  open System.IO

  let summarize filePath =
    let rows = File.ReadAllLines filePath
    let studentCount = (rows |> Array.length) - 1
    rows
    |> Array.skip 1
    |> Array.map Student.fromString
    |> Array.sortBy (fun student -> student.GivenName)
    |> Array.iter Student.printMeanScore