using System;
using hw4.FS;
using Xunit;

namespace hw1.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, "+", 2, 4)]
        [InlineData(2, "-", 3, -1)]
        [InlineData(3, "-", 2, 1)]
        [InlineData(2, "*", 1, 2)]
        [InlineData(6, "/", 6, 1)]
        [InlineData(3, "/", 6, 0)]
        public void Calculate_Operation_IsCorrect(int val1, string operation, int val2, int expected)
        {
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(2, "", 2, 0)]
        [InlineData(2, "sad", 3, 0)]
        [InlineData(2, "3", 3, 0)]
        public void Calculate_Operation_IsNotCorrect(int val1, string operation, int val2, int expected)
        {
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(expected,result);
        }
        
        [Fact]
        public void WhenOperationIncorrect()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Calculate(5,"/", 0));
        }
    }
}