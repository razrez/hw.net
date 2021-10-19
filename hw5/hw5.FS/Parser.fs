module hw5.FS.Parser
open hw5.ResBuilder
let TryToParse args=
    //1
    let checkArgsLength (args:string[]) =
        match args.Length with
        | 3 -> Ok args
        | _ -> Error $"3 arguments were expected! Not {args.Length}"
        
    //2    
    let parseOperation (args:string[]) =
        let IsExpectedOperation arg = match arg with
            | "+" -> Ok Operation.Plus
            | "-" -> Ok Operation.Minus
            | "*" -> Ok Operation.Multiply
            | "/" -> Ok Operation.Divide
            | _ -> Error $"Unsupported operation: {arg}"
        //help-method
        res{
            let! operation = IsExpectedOperation args.[1]
            return  args.[0], operation, args.[2]
        }
    
    //3
    let parseArgs (arg1, operation, arg2) =
        let parseArg arg =
            try Ok(arg |> decimal)
            with _ -> Error $"{arg} is wrong argument"
        //help-method    
        res{
            let! val1 = parseArg arg1
            let! val2 = parseArg arg2
            return val1, operation, val2 
        }
    checkArgsLength args >>= parseOperation >>= parseArgs 


    
    