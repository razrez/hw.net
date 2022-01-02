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
        [InlineData(new[] {"1","/","0"},1)] //divide by zero
        public void TryToParse_Return0(string[] args, int expected)
        {
            var res = Program.Main(args);
            Assert.Equal(expected,res);
        }
    }
}