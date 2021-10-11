module hw4.FS.Parser

    open System
    let IsExpectedOperation =
        [
            "+";
            "-";
            "*";
            "/"
        ]
        
    let tryParseWith (tryParseFunc: string -> bool * _) = tryParseFunc >> function
            | true, v    -> Some v
            | false, _   -> None
            
    let parseInt = tryParseWith Int32.TryParse
    let exists (x : int option) =
        match x with
        | Some(x) -> true
        | None -> false
        
    let TryToParse (args:string[]) =
        let tryParseWith (tryParseFunc: string -> bool * _) = tryParseFunc >> function
            | true, v    -> Some v
            | false, _   -> None
            
        let parseInt = tryParseWith Int32.TryParse
        let exists (x : int option) =
            match x with
            | Some(x) -> true
            | None -> false
            
        if args.Length <> 3 then
            raise (ArgumentException $"3 arguments were expected ! Not {args.Length}")
        
        else if List.contains args.[1] IsExpectedOperation = false then 2 //if unsupported operation
        
        else if (parseInt args.[0] |> exists <> true
                && parseInt args.[2] |> exists <> true || args.[1] = "/" && args.[2] = "0") = false
                 then 1 //if there are no int args or DivideByZero
        else 0