using hw8.Services;
using Xunit;

namespace hw8.Tests
{
    public class CalculatorXUnitTests
    {
        private static string CalculateResult(double var1, string operation, double var2)
        {
            return new Calculator().Calculate(var1,operation,var2);
        }
        [Theory]
        [InlineData(1,"plus",2,"3")]
        [InlineData(1,"plus",0,"1")]
        [InlineData(1,"minus",1,"0")]
        [InlineData(1,"minus",-8,"9")]
        [InlineData(2.5,"multiply",10,"25")]
        [InlineData(25,"multiply",-3,"-75")]
        [InlineData(3,"divide",2,"1.5")]
        [InlineData(7.5,"divide",2,"3.75")]
      
        public void Test1(double val1,string operation, double val2, string expResult)
        {
            var act = CalculateResult(val1, operation, val2);
            Assert.Equal(expResult,act);
        }
    }
}