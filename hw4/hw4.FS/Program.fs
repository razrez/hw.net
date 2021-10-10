// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open hw4.FS

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    let res = Calculator.Calculate 2 "*" 8
    printfn "Hello world %s" message
    printfn $"{res}" 
    
    0 // return an integer exit code