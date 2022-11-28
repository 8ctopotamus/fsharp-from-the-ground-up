open System
open Classes

[<EntryPoint>]
let main argv =
  let namePrompt = ConsolePrompt("Please enter your name", 3)
  namePrompt.BeepOnError <- false
  namePrompt.ColorScheme <- ConsoleColor.Cyan, ConsoleColor.DarkGray
  // namePrompt.ColorScheme <- ConsoleColor.Cyan, ConsoleColor.Cyan
  let name = namePrompt.GetValue()
  // printfn "Hello %s" name

  let favColorPrompt = ConsolePrompt("What is your favorite color?", 3)  
  let favColor = favColorPrompt.GetValue()

  let person = Person(name, favColor)
  printfn "%s" (person.Description())

  0