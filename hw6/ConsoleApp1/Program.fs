open System.Net
open FSharp.Data
let doRequest =
    async {
        let! r1 = Http.AsyncRequest "https://localhost:5001/calculate?arg1=5&operation=*&arg2=7"
        let str =
            match r1.Body with
            | HttpResponseBody.Text t -> t
            | HttpResponseBody.Binary _ -> "Binary"
            
        return str
    }

[<EntryPoint>]
let main argv =
    let r = doRequest |> Async.RunSynchronously
    
    printfn $"{r}"
    0