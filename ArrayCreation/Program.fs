open System

[<EntryPoint>]
let main argv =

  // Arrays

  // let isEven x =
  //   x % 2 = 0

  // let todayIsThursday() =
  //   DateTime.Now.DayOfWeek = DayOfWeek.Thursday

  // // let numbers = [| 1; 2; 4; 8; 16 |]

  // let numbers =
  //   [|
  //     if todayIsThursday() then 42
  //     for i in 1..9 do
  //       let x = i * i
  //       if x |> isEven then
  //         x
  //     999
  //   |]

  // printfn "%A" numbers

  // let total =
  //   [| for i in 1..1000 do yield i * i|]
  //   |> Array.sum

  // printfn "%i" total

  // let numbers2 = Array.init 5 (fun i -> pown 2 i)
  // printfn "%A" numbers2

  // let initiallyZeros = Array.zeroCreate<int> 10
  // initiallyZeros.[0] <- 42
  // printfn "%A" initiallyZeros


  // Example of reading Stream of data (eg Audio) 
  // let readByts length (stream: Stream) =
  //   let buffer = Array.zeroCreate<byte> length
  //   let count = stream.Read(buffer, 0, length)
  //   if count = length then
  //     buffer
  //   else
  //     raise <| EndOfStreamException()


  // Sequences

  let total = 
    seq { for i in 1..1000 -> i * i}
    |> Seq.sum
  
  printfn "The total is: %i" total
  
  
  0