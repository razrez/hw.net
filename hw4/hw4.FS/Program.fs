open hw4.FS

[<EntryPoint>]
let main argv =
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operation = ""
    let parsRes = Parser.TryToParse argv &val1 &operation &val2
    printfn $"{parsRes}"
    if (parsRes <> 0) then
        parsRes
    else
        printfn $"{argv.[0]}{argv.[1]}{argv.[2]}={Calculator.Calculate val1 operation val2}"
        0 // return an integer exit code