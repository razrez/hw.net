using Giraffe;
using hw8;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Benchmark
{
    public class FsharpCustomWebApplicationFactory: WebApplicationFactory<Web.Calculator.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<Web.Calculator.Startup>().UseTestServer();
                });
            return builder;
        }
    }
}