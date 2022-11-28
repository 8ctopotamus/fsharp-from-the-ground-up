open System

module Dates =
 
    let from (startDate : DateTime) =
        Seq.initInfinite (fun i -> startDate.AddDays(float i))

module MathSequence =
 
    type State = { N : int; Pn2 : int; Pn1 : int }
 
    let pell =
        { N = 0; Pn2 = 0; Pn1 = 0 }
        |> Seq.unfold (fun state ->
            let pn =
                match state.N with
                | 0 | 1 
                    -> state.N
                | _ 
                    -> 2*state.Pn1 + state.Pn2
            let n' = state.N + 1
            Some(pn, { N = n'; Pn2 = state.Pn1; Pn1 = pn } ))

module Drunkard =
 
    let r = System.Random()
 
    /// Returns a random integer between -1 and +1 inclusive:
    let step() =
        r.Next(-1, 2)
 
    type Position = { X : int; Y : int }
 
    let walk =
        { X = 0; Y = 0 }
        |> Seq.unfold (fun position ->
            let x' = position.X + step()
            let y' = position.Y + step()
            let position' = { X = x'; Y = y' }
            Some(position', position'))

[<EntryPoint>]
let main argv =
 
    // Dates.from DateTime.Now
    // |> Seq.filter (fun d -> d.Month = 1 && d.Day = 1)
    // |> Seq.truncate 10
    // |> Seq.iter (fun d -> printfn "%i %s" d.Year (d.DayOfWeek.ToString()))

    // MathSequence.pell
    // |> Seq.truncate 10
    // |> Seq.iter (fun x -> printf "%i, " x)

    // printfn "..."

    printf "Drunkard's walk"
    Drunkard.walk
    |> Seq.take 100
    |> Seq.iter (fun p -> printfn "X: %i Y: %i" p.X p.Y)
 
    0 
