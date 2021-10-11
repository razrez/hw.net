// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Collections.Generic
open hw4.FS

// Define a function to construct a message to print
let from whom = sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    let res = Parser.TryToParse argv
    printfn "Hello world %s" message
    printfn $"{System.Int32.TryParse argv.[0] }"

    0 // return an integer exit code
