using hw4.FS;
using Xunit;

namespace hw1.Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData(new[] {"2","+","3"},0)]
        [InlineData(new[] {"2","-","3"},0)]
        [InlineData(new[] {"2","*","3"},0)]
        [InlineData(new[] {"2","/","3"},0)]
        public void TryToParse_Return0(string[] args, int expected)
        {
            var res = Parser.TryToParse(args);
            Assert.Equal(expected,res);
        }
        
        [Theory]
        [InlineData(new[] {"2.0","+","3"},1)]
        [InlineData(new[] {"2","*","asdas"},1)]
        [InlineData(new[] {"3","/","0"},1)] //divide by zero
        public void TryToParse_Return1(string[] args, int expected)
        {
            var res = Parser.TryToParse(args);
            Assert.Equal(expected,res);
        }
        
        [Theory]
        [InlineData(new[] {"2","%","3"},2)]
        [InlineData(new[] {"2","2","3"},2)]
        [InlineData(new[] {"2"," ","3"},2)]
        public void TryToParse_Return2(string[] args, int expected)
        {
            var res = Parser.TryToParse(args);
            Assert.Equal(expected,res);
        }

    }
}