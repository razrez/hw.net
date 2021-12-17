using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using System;
using System.Net;
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
            
        }
    }
}