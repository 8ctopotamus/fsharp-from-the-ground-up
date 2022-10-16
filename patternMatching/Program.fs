open System

module Green = 

    let bottles n =
        match n with
        | 1 -> "One green bottle"
        | 2 -> "Two green bottles"
        | _ -> sprintf "%i green bottles" n // default case

module Option = 

    let describe x =
        match x with
        | Some v -> sprintf "The value was %O" v
        | None -> sprintf "There was no value"

module Array =

    let describe a =
        match a with
        | [||] -> "An empty array"
        | [|x|] -> sprintf "An array with one element: %O" x
        | [|x; y|] -> sprintf "An array with two elements: %O, %O" x y
        | _ -> sprintf "An array with %i elements." a.Length

module Tuple =

    let describe2 t =
        let a, b = t
        sprintf "A 2-tuple, first value: %O second value: %O" a b 

[<EntryPoint>]
let main argv =

    for i in 1..10 do
        printfn "%s" (Green.bottles i)

    printfn "---"
    printfn "%s" (Some 99 |> Option.describe)
    printfn "%s" (Some "abc" |> Option.describe)
    printfn "%s" (None |> Option.describe)      

    printfn "---"
    printfn "%s" ([||] |> Array.describe)
    printfn "%s" ([|"hello"|] |> Array.describe)
    printfn "%s" ([|"hello"; "world"|] |> Array.describe)
    printfn "%s" ([|"world"; "hello"|] |> Array.describe)
    printfn "%s" ([|"the"; "cat"; "sat"|] |> Array.describe)

    printfn "---"
    printfn "%s" (("hello", "world") |> Tuple.describe2)
    0