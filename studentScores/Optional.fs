namespace StudentScores

// This is just to demonstrate that we can replace the built-in 'option'
// type with a generic Discriminated Union.  You wouldn't normally replace
// the option type in this way.

type Optional<'T> =
    | Something of 'T
    | Nothing

module Optional =
 
    let defaultValue (d : 'T) (optional : Optional<'T>) =
        match optional with
        | Something v -> v
        | Nothing -> d