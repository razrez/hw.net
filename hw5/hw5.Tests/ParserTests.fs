module hw5.Tests.ParserTests
open hw5.ResBuilder
open Xunit

[<Theory>]
[<InlineData("+", Operation.Plus)>]
[<InlineData("-", Operation.Minus)>]
[<InlineData("*", Operation.Multiply)>]
[<InlineData("/", Operation.Divide)>]
let TryToParse_Return_CorrectOperationResult (operation, excepted) =
    Assert.Equal(Ok((decimal 2.5 ),excepted,(decimal 87)),
                 Parser.TryToParse [|"2.5";operation;"87"|])
    
[<Fact>]
let TryToParse_Return_AllCorrectResult1 () =
    Assert.Equal(Ok((decimal 31.4 ),Operation.Multiply,(decimal 73.4)),
                 Parser.TryToParse [|"31.4";"*";"73.4"|])
    
[<Fact>]
let TryToParse_Return_AllCorrectResult2 () =
    Assert.Equal(Ok((decimal 32.3 ),Operation.Divide,(decimal 63.4)),
                 Parser.TryToParse [|"32.3";"/";"63.4"|])

[<Fact>]
let TryToParse_Return_AllCorrectResult3 () =
    Assert.Equal(Ok((decimal 33.2 ),Operation.Plus,(decimal 53.4)),
                 Parser.TryToParse [|"33.2";"+";"53.4"|])
    
[<Fact>]
let TryToParse_Return_AllCorrectResult4 () =
    Assert.Equal(Ok((decimal 33.2 ),Operation.Minus,(decimal 43.4)),
                 Parser.TryToParse [|"33.2";"-";"43.4"|])

[<Fact>]
let TryToParse_Error_WrongInputLengt () =
    Assert.Equal(Error $"3 arguments were expected! Not 4",
                 Parser.TryToParse [|"11";"/";"-142";"dds"|])
    
[<Fact>]
let TryToParse_Error_UnsupportedOperation () =
    Assert.Equal(Error "Unsupported operation: %",
                 Parser.TryToParse [|"12.5";"%";"3.7"|])    
    
[<Fact>]
let TryToParse_Error_NotArg () =
    Assert.Equal(Error "sever228 is wrong argument",
                 Parser.TryToParse [|"4";"+";"sever228"|] )