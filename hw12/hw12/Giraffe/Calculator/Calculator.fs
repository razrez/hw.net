module Fsharp.Calculator
open Fsharp
open ResultBuilder

let Calculate (arg1 : double) (operation) (arg2 : double) =
        if (operation = "/" && arg2 = (double) 0) then
            Failure "Attempted division by zero."
        else
            let result =
                match operation with
                |  "+" ->   (arg1 + arg2) 
                |  "-" ->   (arg1 - arg2)
                |  "*" ->   (arg1 * arg2)
                | "/" ->    (arg1/arg2)
            Success result

