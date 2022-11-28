namespace StudentScores
 
type Student =
    {
        Surname : string
        GivenName : string
        Id : string
        SchoolName: string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }
 
module Student =

    open System.Collections.Generic
 
    let nameParts (s : string) =
        let elements = s.Split(',')
        match elements with
        | [|surname; givenName|] -> 
            {| Surname = surname.Trim()
               GivenName = givenName.Trim() |}
        | [|surname|] ->
            {| Surname = surname.Trim()
               GivenName = "(None)" |}
        | _ -> 
            raise (System.FormatException(sprintf "Invalid student name format: \"%s\"" s))
 
    let fromString (schoolCodes : IDictionary<int, string>) (s : string) =
        let elements = s.Split('\t')
        let name = elements.[0] |> nameParts
        let id = elements.[1]
        let schoolCode = elements.[2] |> int
        let schoolName = schoolCodes.[schoolCode]
        let scores =
            elements
            |> Array.skip 3
            |> Array.map TestResult.fromString
            |> Array.choose TestResult.tryEffectiveScore
        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Surname = name.Surname
            GivenName = name.GivenName
            Id = id
            SchoolName = schoolName
            MeanScore = meanScore
            MinScore = minScore
            MaxScore = maxScore
        }
 
    let printSummary (student : Student) =
        printfn "%s, %s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Surname student.GivenName student.Id student.SchoolName student.MeanScore student.MinScore student.MaxScore