module HW5.ResBuilder
type ResultBuilder() =
    member this.Zero() = Error "Arguments have error(s)"
    member this.Bind(x, f) =
        match x with    
        | Ok x -> f x
        | Error error -> Error error
    member this.Return x = Ok x
let res = ResultBuilder()