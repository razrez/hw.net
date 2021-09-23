using Xunit;

namespace hw1.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(new[] {"2","+","3"},0)]
        [InlineData(new[] {"2","-","3"},0)]
        [InlineData(new[] {"2","*","3"},0)]
        [InlineData(new[] {"2","/","3"},0)]
        [InlineData(new[] {"2.0","+","3"},1)]
        [InlineData(new[] {"2.0","*","asides"},1)]
        [InlineData(new[] {"0","/",""},1)]
        [InlineData(new[] {"2","%","3"},2)]
        [InlineData(new[] {"2","2","3"},2)]
        [InlineData(new[] {"2"," ","3"},2)]
        public void TryToParse_Return0(string[] args, int expected)
        {
            //Act
            var res = Program.Main(args);
            
            //Assert
            Assert.Equal(expected,res);
        }
    }
}