open System
open GenericPoints

[<EntryPoint>]
let main argv =

    let pFloat1 = { X = 1.0; Y = 2.0 }
    let pFloat2 = pFloat1 |> Point.moveBy 3.0 4.0
    printfn "pFloat1: %A pFloat2: %A" pFloat1 pFloat2

    // Uncomment this code to test your generic version...

    let pInt1 = { X = 1; Y = 2 }
    let pInt2 = pInt1 |> Point.moveBy 3 4
    printfn "pInt: %A pInt2: %A" pInt1 pInt2
    
    let pSingle1 = { X = 1.0f; Y = 2.0f }
    let pSingle2 = pSingle1 |> Point.moveBy 3.0f 4.0f
    printfn "pSingle: %A pSingle2: %A" pSingle1 pSingle2

    // ...end

    // let pString1 = { X = "a"; Y = "b" }
    // let pString2 = pString1 |> Point.moveBy "c" "d"
    // printfn "pString1: %A pString2: %A" pString1 pString2

    // let pFloat3 = pFloat2 |> Point.scaleBy 2.0
    // let pInt3 = pInt2 |> Point.scaleBy 2
    // let pSingle3 = pSingle2 |> Point.scaleBy 2.0f
    // let pString3 = pString2 |> Point.scaleBy "factor"
    
    0
