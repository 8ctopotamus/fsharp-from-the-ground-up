namespace StudentScores 

module Summary =
 
    open System.IO

    let printGroupSummary (surname : string) (students : Student[]) =
        printfn "%s" (surname.ToUpperInvariant())
        students  
        |> Array.sortBy (fun student ->
            student.GivenName, student.Id)
        |> Array.iter (fun student ->
            printfn "\t%20s\t%s\t%0.1f\t%0.1f\t%0.1f"
                student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore)
 
    let summarize schoolCodesFilePath filePath =
        let rows = 
            File.ReadLines filePath
            |> Seq.cache
        let studentCount = (rows |> Seq.length) - 1
        printfn "Student count %i" studentCount
        let schoolCodes = SchoolCodes.load schoolCodesFilePath
        rows
        |> Seq.skip 1
        |> Seq.map (Student.fromString schoolCodes)
        |> Seq.sortByDescending (fun student -> student.MeanScore)
        |> Seq.iter Student.printSummary

    // let summarize filePath =
    //     let rows = File.ReadAllLines filePath
    //     let studentCount = (rows |> Array.length) - 1
    //     printfn "Student count %i" studentCount
    //     rows
    //     |> Array.skip 1
    //     |> Array.map Student.fromString
    //     |> Array.groupBy (fun s -> s.Surname)
    //     |> Array.sortBy fst
    //     |> Array.iter (fun (surname, students) -> 
    //         printGroupSummary surname students)    
     