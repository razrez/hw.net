module hw5.Program
open hw5.ResBuilder
[<EntryPoint>]
let main argv =
    match Parser.TryToParse argv >>= Calculator.Calculate with
    | Ok res -> printf $"{res}";0
    | Error exp -> printf $"{exp}"; 1