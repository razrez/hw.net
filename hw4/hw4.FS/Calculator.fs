module hw4.FS.Calculator

        let Calculate (val1:int) operation (val2:int) =
            match operation with
            | "+" -> val1 + val2
            | "-" -> val1 - val2
            | "*" -> val1 * val2
            | "/" -> val1 / val2
            | _ -> 0