open hw4.FS

[<EntryPoint>]
let main argv =
    let parsRes = Parser.TryToParse argv
    printfn $"{parsRes}"
    if (parsRes <> 0) then
        parsRes
    else
        printfn $"{argv.[0]}{argv.[1]}{argv.[2]}={Calculator.Calculate (argv.[0] |> int) argv.[1] (argv.[2] |> int)}"
        0 // return an integer exit code