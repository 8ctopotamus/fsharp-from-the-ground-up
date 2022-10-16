namespace StudentScores

type TestResult =
  | Absent
  | Excused
  | Scored of float

module TestResult =

  let fromString s = 
    if s = "A" then
      Absent
    elif s = "E" then
      Excused
    else
      let value = s |> float
      Scored value

  let tryEffectiveScore (testResult : TestResult) =
    match testResult with
    | Absent -> Some 0.0
    | Excused -> None
    | Scored score -> Some score