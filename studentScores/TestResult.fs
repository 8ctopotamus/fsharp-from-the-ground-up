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

  let effectiveScore (testResult : TestResult) =
    match testResult with
    | Absent -> 0.0
    | Excused -> 50.0
    | Scored score -> score