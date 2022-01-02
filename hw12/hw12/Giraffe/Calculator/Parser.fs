module Fsharp.Parser
open Fsharp
open ResultBuilder
    
    let TryParseArguments (args : string[]) =
            let supportedOperation operation =
                match operation with
                | "plus" -> Success "+"
                | "subtract" -> Success "-"
                | "multiply"  -> Success "*"
                | "divide"  -> Success "/"
                | _ -> Failure $"Invalid operation."
                
            let parseVal x =
                try Success (x |> double) with
                | _ -> Failure $"Invalid value."
            (parseVal args.[0], supportedOperation args.[1], parseVal args.[2])