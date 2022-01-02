module Giraffe.Startup

open Fsharp
open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Calculator
open ResultBuilder
open Parser

let calculatorHandler (arg1 : string, operation  : string, arg2 : string) : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        (let mutable op = operation
         let result = result {
            let tempArg1, tempOp, tempArg2 = TryParseArguments [|arg1; operation; arg2|]
            let! val1 = tempArg1
            let! oper = tempOp
            op <- oper
            let! val2 = tempArg2
            let calculated = Calculate val1 oper val2
            return calculated
        }
        match result with
         | Success result -> setStatusCode 200 >=> json result
         | Failure error -> setStatusCode 400 >=> json error
        ) next ctx
        
let webApp =
    choose [
        GET >=>
            choose [
                routef "/calculator/arg1=%s&operation=%s&arg2=%s" calculatorHandler
            ]
        setStatusCode 404 >=> text "Not Found" ]
    
type Startup() =
    member __.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member __.Configure (app : IApplicationBuilder)
                        (env : IHostEnvironment)
                        (loggerFactory : ILoggerFactory) =
        app.UseGiraffe webApp