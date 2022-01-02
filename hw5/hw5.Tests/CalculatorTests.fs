module hw5.Tests.CalculatorTests
open hw5.ResBuilder
open Xunit

[<Theory>]
[<InlineData(-3.5, 9.5, 6)>]
[<InlineData(1, 5, 6)>]
[<InlineData(-2.22, -3.33, -5.55)>]
[<InlineData(-8, 7, -1)>]
[<InlineData(-8, 0, -8)>]
let Calculate_Plus_IsCorrect (val1, val2, expected) =
    res{
        let! result = Calculator.Calculate (val1, Operation.Plus, val2)
        Assert.Equal(expected, result)
    }
    
[<Theory>]
[<InlineData(25, 7, 18)>]
[<InlineData(8, -7, 15)>]
[<InlineData(-8.6, 8.4, -17)>]
[<InlineData(-8.6, 0, -8.6)>]
let Calculate_Minus_IsCorrect (val1, val2, expected) = 
    res{
        let! result = Calculator.Calculate (val1, Operation.Minus, val2)
        Assert.Equal(expected, result)
    }
    
[<Theory>]
[<InlineData(5, 5, 25)>]
[<InlineData(-0.4, -0.4, 0.16)>]
[<InlineData(8, -3, -24)>]
[<InlineData(-9, 3, -27)>]
[<InlineData(-3, -2, 6)>]
[<InlineData(-3, 0, 0)>]
let Calculate_Multiply_IsCorrect (val1, val2, expected) = 
    res{
        let! result = Calculator.Calculate (val1, Operation.Multiply, val2)
        Assert.Equal(expected, result)
    }

[<Theory>]
[<InlineData(8, 4, 2)>]
[<InlineData(9, -2, -4.5)>]
[<InlineData(-10.5, 5, -2.1)>]
[<InlineData(2, -1, -2)>]
[<InlineData(0, -1, 0)>]
let Calculate_Divide_IsCorrect (val1,  val2, expected) = 
    res{
        let! result = Calculator.Calculate (val1, Operation.Divide, val2)
        Assert.Equal(expected, result)
    }
    
[<Fact>]
let Calculate_DivideByZero_IsNotCorrect = 
    let result = Calculator.Calculate (decimal 5, Operation.Divide, decimal 0)
    Assert.Equal(Error "Second argument is zero!", result)
    
[<Fact>]
let Calculate_DivideByZero_IsCorrect = 
    let result = Calculator.Calculate (decimal 5, Operation.Divide, decimal 0)
    Assert.Equal(Error "Second argument is zero!", result)