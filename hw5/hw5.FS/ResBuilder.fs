module hw5.ResBuilder
type Operation =
    | Plus = 0
    | Minus = 1
    | Multiply = 2
    | Divide = 3
////////////////////////////////////////////////////////           
type ResultBuilder() =
    member this.Bind(x, f) =
        match x with    
        | Ok x -> f x
        | Error error -> Error error
    member this.Return x = Ok x
    member this.Zero() = Error "Wrong Arguments!"
let res = ResultBuilder()
let (>>=) x f = Result.bind f x