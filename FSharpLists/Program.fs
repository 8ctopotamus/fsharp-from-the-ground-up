open System

// NOTE: cannot mutate List elements

[<EntryPoint>]
let main argv =

    let numbers = [1; 2; 4; 8; 16]
 
    let moreNumbers = 
        [
            for i in 0..4 -> pown 2 i
        ]
 
    let yetMoreNumbers = List.init 5 (fun i -> pown 2 i)        
 
    let total =
        [ for i in 1..1000 -> i * i ]
        |> List.sum
 
    let thirdNumber = yetMoreNumbers.[2]
    // yetMoreNumbers.[1] <- 99

    let strings = ["the"; "cat"; "sat"]
    printfn "strings: %A" strings

    let strings2 = "sometimes" :: strings
    printfn "strings2: %A" strings2

    match strings2 with 
    | head::tail -> 
        printfn "head: \"%s\", tail: %A" head tail
    | [] -> 
        printfn "Empty list"
        
    0