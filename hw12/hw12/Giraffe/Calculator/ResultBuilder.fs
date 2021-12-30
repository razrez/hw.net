module Fsharp.ResultBuilder

type Result<'a> =
    | Success of 'a
    | Failure of string
    
    type ResultBuilder() =
        let bind f res =
            match res with
            | Success x -> f x
            | Failure errs -> Failure errs
        member this.Return x = x
        member this.ReturnFrom x = Success x
        member this.Bind(x,f) = bind f x

    let result = new ResultBuilder()       