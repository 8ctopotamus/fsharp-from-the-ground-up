open System

let sayHello person =
  printfn "Hello %s from my F# program!" person

[<EntryPoint>]
let main argv =
  Array.iter sayHello argv
  printfn "Nice to meet you."
  0