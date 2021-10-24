using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();

            var response = await httpClient
                .GetAsync("http://localhost:5000/add?v1=3&v2=2");
            var str = await response.Content
                .ReadAsStreamAsync();
            
            Console.WriteLine(str);
            Console.WriteLine(response.Content.Headers.Allow);
        }
    }
}