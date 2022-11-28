namespace StudentScores
 
type TestResult =
    | Absent
    | Excused
    | Voided
    | Scored of float
 
module TestResult =
 
    let fromString s =
        if s = "A" then
            Absent
        elif s = "E" then
            Excused
        elif s = "V" then
            Voided
        else
            let value = s |> float
            Scored value
 
    let tryEffectiveScore (testResult : TestResult) =
        match testResult with
        | Absent -> Some 0.0
        | Excused 
        | Voided -> None
        | Scored score -> Some score
