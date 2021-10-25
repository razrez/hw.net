module hw5.Calculator
open hw5.ResBuilder
let Calculate (val1, operation, val2) =
    let tryDivide arg1 arg2 =
        if arg2 = decimal 0 then Error "Second argument is zero!"
        else Ok(arg1 / arg2)
    //help-method
    res{
        match operation with
        | Operation.Plus -> return val1 + val2
        | Operation.Minus -> return val1 - val2
        | Operation.Multiply -> return val1 * val2
        | _ -> let! res =  tryDivide val1 val2
               return res
        }