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
            //Act
            var res = ParserIL.TryToParse(args, out _, out _, out _);
            
            //Assert
            Assert.Equal(expected,res);
        }
        
        [Theory]
        [InlineData(new[] {"2.0","+","3"},1)]
        [InlineData(new[] {"2.0","*","asdas"},1)]
        [InlineData(new[] {"0","/",""},1)]
        public void TryToParse_Return1(string[] args, int expected)
        {
            //Act
            var res = ParserIL.TryToParse(args, out _, out _, out _);
            
            //Assert
            Assert.Equal(expected,res);
        }
        
        [Theory]
        [InlineData(new[] {"2","%","3"},2)]
        [InlineData(new[] {"2","2","3"},2)]
        [InlineData(new[] {"2"," ","3"},2)]
        public void TryToParse_Return2(string[] args, int expected)
        {
            //Act
            var res = ParserIL.TryToParse(args, out _, out _, out _);
            
            //Assert
            Assert.Equal(expected,res);
        }

    }
}