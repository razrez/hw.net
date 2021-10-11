module hw4.FS.Parser
    let IsExpectedOperation =
        [
            "+";
            "-";
            "*";
            "/"
        ]
        
            
    let TryToParse (args:string[]) =
        if List.contains args.[1] IsExpectedOperation = false then 2 //if unsupported operation
        
        else if (box args.[0] :? int = false &&
                 box args.[2] :? int = false
                 || args.[1] = "/" && args.[2] = "0")
                 then 1 //if there are no int args or DivideByZero
        else 0
