using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace hw9.Tests
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
            private readonly string url = "https://localhost:5001/calculator/calculateu?expr=";
            private readonly HttpClient _client;
            public ITest(HostBuilder factory)
            {
                _client = factory.CreateClient();
            }
            
            [Theory]
            [InlineData("(3+8)/2*3", "16,5")]
            [InlineData("(3+3)/12*7+8*9", "75,5")]
            [InlineData("(6-9)", "-3")]
            [InlineData("3", "3")]
            [InlineData("(321312)", "321312")]
            [InlineData("(32)-0,5", "31,5")]
            public async Task CatchingErrors(string expr, string expected)
            {
                await TestCalculation(expr, expected);
            }
            
            private async Task TestCalculation(string expr, string expected)
            {
                var response = await _client.GetAsync($"{url}{expr}");
                var result = await response.Content.ReadAsStringAsync();
                Assert.Equal(expected, result);
            }
        }
    }
}