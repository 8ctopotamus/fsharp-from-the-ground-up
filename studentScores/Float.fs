namespace StudentScores

module Float = 

  let tryFromString (s : string) : float option =
    if s = "N/A" then
      None
    else 
      Some (float s)

  let fromStringOrDefault d s : float=
    s
    |> tryFromString
    |> Option.defaultValue d