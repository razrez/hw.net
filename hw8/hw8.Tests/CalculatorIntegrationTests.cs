using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace hw8.Tests
{
    public class CalculatorIntegrationTests
    {
        public class HostBuilder : WebApplicationFactory<Startup>
        {
            protected override IHostBuilder CreateHostBuilder() =>
                Host
                    .CreateDefaultBuilder()
                    .ConfigureWebHostDefaults(builder => builder
                        .UseStartup<Startup>()
                        .UseTestServer());
        }

        public class ITest : IClassFixture<HostBuilder>
        {
            private readonly string url = "https://localhost:5001/calculator/calculate?";
            private readonly HttpClient _client;
            public ITest(HostBuilder factory)
            {
                _client = factory.CreateClient();
            }

            [Theory]
            [InlineData("0", "plus", "0", "0")]
            [InlineData("1","plus","2","3")]
            [InlineData("1","plus","0","1")]
            [InlineData("1","minus","1","0")]
            [InlineData("25","multiply","-3","-75")]
            [InlineData("3","divide","2","1,5")]
            public async Task CalculateAll_ReturnCorrectAnswer(string val1, string operation, string val2, string expected)
            {
                await TestCalculation(val1, operation, val2, expected);
            }
            
            [Theory]
            [InlineData("1", "plussdfas", "23,4", "Unsupported operation! \nSupported are:" +
                                                  " plus, minus, divide and multiply")]
            [InlineData("1", "plus", "asaa", "Please, enter numbers")]
            [InlineData("", "plus", "", "Please, enter numbers")]
            [InlineData("3", "divide", "0", "divide by zero!")]
            public async Task CatchingErrors(string val1,string operation, string val2, string expected)
            {
                await TestCalculation(val1, operation, val2, expected);
            }
            
            private async Task TestCalculation(string val1, string operation,
                string val2, string expected)
            {
                var response = await _client.GetAsync($"{url}val1={val1}" +
                                                      $"&operation={operation}&val2={val2}");
                var result = await response.Content.ReadAsStringAsync();
                Assert.Equal(expected, result);
            }
        }
    }
}