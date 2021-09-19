using System;
using Xunit;

namespace Homework1.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, "+", 2, 4)]
        [InlineData(2, "+", 3, 5)]
        [InlineData(2, "+", 1, 3)]
        [InlineData(3, "+", 6, 9)]
        public void Calculate_Plus_IsCorrect(int val1, string operation, int val2, int expected)
        {
            //Act
            var result = Calculator.Calculate(val1, operation, val2);
            
            //Assert
            Assert.Equal(expected,result);
        }
    }
}