namespace StudentScores

type TestResult =
  | Absent
  | Excused
  | Score of float

module TestResult =

  let fromString s = 
    if s = "A" then
      Absent
    elif s = "E" then
      Excused
    else
      let value = s |> float
      Score value
