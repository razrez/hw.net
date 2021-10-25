using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace hw6.Tests
{
   
    public class ProgramTests : IClassFixture<CustomWebApplicationFactory<Web.Calculator.Startup>>
    {
        private readonly CustomWebApplicationFactory<Web.Calculator.Startup> _factory;
        public ProgramTests (CustomWebApplicationFactory<Web.Calculator.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("8", "plus", "11", "19.0")]
        [InlineData("8", "minus", "11.5", "-3.5")]
        [InlineData("1", "divide", "4", "0.25")]
        [InlineData("0.4", "multiply", "0.8", "0.32")]
        public async Task DoRequest_And_ReturnCorrectValue(string arg1, string operation, string arg2, string expected)
        {
            await DoRequest(arg1, operation, arg2, expected);
        }
        
        [Theory]
        [InlineData("12.5", "%", "3.7", "\"Unsupported operation: %\"")]
        [InlineData("4", "plus", "sever228", "\"sever228 is wrong argument\"")]
        [InlineData("1", "divide", "4", "0.25")]
        [InlineData("0.4", "multiply", "0.8", "0.32")]
        public async Task DoWrongRequest_And_ReturnErrors(string arg1, string operation, string arg2, string expected)
        {
            await DoRequest(arg1, operation, arg2, expected);
        }

        private async Task DoRequest(string arg1, string operation, string arg2, string expected)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(
                $"http://localhost:5000/calculate?arg1={arg1}&operation={operation}&arg2={arg2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Request_Return_NotFound()
        {
            var client = _factory.CreateClient();
            var response =
                await client.GetAsync($"http://localhost:5000/iwannasleep");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal("Not Found", result);
        }
        
    }
    
    //Setting WebApplicationFactory
    public class CustomWebApplicationFactory<TStartup>:
        WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.
                CreateDefaultBuilder()
                .ConfigureWebHostDefaults
                (conf =>
                { conf.UseStartup<Web.Calculator.Startup>().UseTestServer(); });
        }
    }
  
}
