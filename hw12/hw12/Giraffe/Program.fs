open Fsharp
open hw8
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Giraffe

type Message =
    {
        Text : string
    }
    
module Views =
    open Giraffe.ViewEngine

    let layout (content: XmlNode list) =
        html [] [
            head [] [
                title []  [ encodedText "hw6" ]
                link [ _rel  "stylesheet"
                       _type "text/css"
                       _href "/main.css" ]
            ]
            body [] content
        ]

    let partial () =
        h1 [] [ encodedText "пользователь нижнего интернета" ]

    let index (model : Message) =
        [
            partial()
            p [] [ encodedText model.Text ]
        ] |> layout
        
let indexHandler (name : string) =
    let greetings = sprintf "Hello %s, from интернета!" name
    let model     = { Text = greetings }
    let view      = Views.index model
    htmlView view

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .UseStartup<Startup>()
                    |> ignore)
        .Build()
        .Run()
    0