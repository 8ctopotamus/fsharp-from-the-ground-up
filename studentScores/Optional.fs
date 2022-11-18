namespace StudentScores

// Generics - placeholder for types that can be used later

type Optional<'T, 'R> = 
  | Something of 'T
  | Something2 of 'R
  | Something3 of 'T * 'R
  | Nothing

module Demo =
  
  let a = Something "abc"
  let b = Something 1
  let c = Something 1.2
  let d = Nothing
  let e = List<int>.Empty
  let f = Something2 1
  let g = Something3 (1, Nothing)

module Optional = 
  let defaultValue (d : 'T) (optional: Optional<'T, 'R>) =
    match optional with 
    | Something v -> string v
    | Something2 r -> string r
    | Something3 (v, r) -> string v + string r
    | Nothing -> string "Nothing"