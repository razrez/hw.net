module hw4.FS.Parser

    open System
    let ExpectedOperation =
        [
            "+";
            "-";
            "*";
            "/"
        ]
        
    let TryToParse (args:string[]) (val1 : outref<int>) (operation : outref<string> ) (val2 : outref<int>) =
        let tryParseWith (tryParseFunc: string -> bool * _) = tryParseFunc >> function
            | true, v    -> Some v
            | false, _   -> None
        let parseInt = tryParseWith Int32.TryParse
        let exists (x : int option) =
            match x with
            | Some(x) -> true
            | None -> false
            
        if args.Length <> 3 then
            printfn $"3 arguments were expected ! Not {args.Length}"
            1
        elif List.contains args.[1] ExpectedOperation = false then 2 //if unsupported operation
        elif parseInt args.[0] |> exists = false || parseInt args.[2] |> exists = false
                || (args.[1] = "/" && args.[2] = "0")
                 then 1 //if there are no int args or DivideByZero
        else
            val1 <- args.[0] |> int
            operation <- args.[1]
            val2 <- args.[2] |> int
            0