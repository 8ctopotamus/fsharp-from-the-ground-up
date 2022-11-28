namespace Classes

open System

type ConsolePrompt(message: string, maxTries : int) = 
  do // NOTE: not binding a value, so have to use 'do' here
    if String.IsNullOrWhiteSpace(message) then
      raise <| ArgumentException("Null or empty", "message") // NOTE: using <| saves an extra pair of parenthesis 
  let trimmedMessage = message.Trim()
  let mutable tryCount = 0

  let mutable foreground = ConsoleColor.White
  let mutable background = ConsoleColor.Black

  member this.ColorScheme
    with get() =
      foreground, background
    and set(fg, bg) =
      if fg = bg then
        raise <| ArgumentException("Foreground and background must be different")
      foreground <- fg
      background <- bg

  member this.GetValue() =
    tryCount <- tryCount + 1
    Console.ForegroundColor <- foreground
    Console.BackgroundColor <- background
    printf "%s: " trimmedMessage // NOTE: in class Members (methods), you can use any constructor params OR values bound in constuctor body above
    Console.ResetColor()
    let input = Console.ReadLine()
    if String.IsNullOrWhiteSpace(input) && tryCount < maxTries then
      if this.BeepOnError then
        Console.Beep()
      this.GetValue()
    else
      input

  member val BeepOnError = true
    with get, set
