namespace StudentScores
 
module Float =
 
    let tryFromString s =
        if s = "N/A" then
            // None
            Nothing
        else
            // Some (float s)
            Something (float s)
 
    let fromStringOr d s =
        s
        |> tryFromString
        // |> Option.defaultValue d
        |> Optional.defaultValue d
