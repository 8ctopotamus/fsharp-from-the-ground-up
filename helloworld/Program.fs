open System

[<EntryPoint>]
let main argv =
  for person in argv do 
    printfn "Hello %s from my F# program!" person
  printfn "Nice to meet you."
  0