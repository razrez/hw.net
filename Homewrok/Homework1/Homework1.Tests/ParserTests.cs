using Xunit;
using System;

namespace Homework1.Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData(new[] {"2","+","3"},0)]
        [InlineData(new[] {"2.0","+","3"},1)]
        [InlineData(new[] {"2","%","3"},2)]
        public void TryToParse_IsParsable(string[] args, int expected)
        {
            //Act
            var res = Parser.TryToParse(args, out var val1, out var operation, out var val2);
            
            //Assert
            Assert.Equal(expected,res);
        }

    }
}