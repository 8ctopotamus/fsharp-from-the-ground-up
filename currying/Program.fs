open System

// Example 1: partial application of curried parameters
// let add a b =
//   a + b

// let c = add 2 3

// let d = add 2 // if you give a func some params...

// let e = d 4 // ...it returns a func that expects the rest of the params

// [<EntryPoint>]
//   let main argv = 
//     printfn "e: %i" e
//     0

// Example 2: 
let quote symbol s =
  sprintf "%c%s%c" symbol s symbol

let singleQuote = quote '\''
let doubleQuote =  quote '"'

[<EntryPoint>]
let main argv = 
  printfn "%s" (singleQuote "It was the best of times, it was the worst of times")
  printfn "%s" (doubleQuote "It was the best of times, it was the worst of times")
  0