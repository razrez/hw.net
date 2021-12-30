using System.Net.Http;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    public class BenchmarkCalculator
    {
        private HttpClient _csharpClient;
        private HttpClient _fsharpClient;

        [GlobalSetup]
        public void GlobalSetUp()
        {
            _csharpClient = new CsharpCustomWebApplicationFactory().CreateClient();
            _fsharpClient = new FsharpCustomWebApplicationFactory().CreateClient();
        }
        
        [Benchmark]
        public void CsharpPlusOperation()
        {
            var response = _csharpClient.GetAsync(
                $"https://localhost:5001/calculator/calculate?val1=123&operation=plus&val2=212").GetAwaiter().GetResult();
        }
        
        [Benchmark]
        public void CsharpMinusOperation()
        {
            var response = _csharpClient.GetAsync(
                $"https://localhost:5001/calculator/calculate?val1=231&operation=minus&val2=32").GetAwaiter().GetResult();
        }
        
        [Benchmark]
        public void CsharpDivideOperation()
        {
            var response = _csharpClient.GetAsync(
                $"https://localhost:5001/calculator/calculate?val1=3&operation=divide&val2=2").GetAwaiter().GetResult();
        }
        
        [Benchmark]
        public void CsharpMultiplyOperation()
        {
            var response = _csharpClient.GetAsync(
                $"https://localhost:5001/calculator/calculate?val1=4&operation=multiply&val2=123").GetAwaiter().GetResult();
        }

        [Benchmark]
        public string FsharpPlusOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"https://localhost:5001/calculate?arg1=123&operation=plus&arg2=212").GetAwaiter().GetResult();
            return response.ToString();
        }
        
        [Benchmark]
        public string FsharpMinusOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"https://localhost:5001/calculate?arg1=231&operation=plus&arg2=32").GetAwaiter().GetResult();
            return response.ToString();
        }
        
        [Benchmark]
        public string FsharpDivisionOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"https://localhost:5001/calculate?arg1=3&operation=divide&arg2=2").GetAwaiter().GetResult();            
            return response.ToString();
        }
        
        [Benchmark(Description = "f#: 4 * 123")]
        public string FsharpMultiplyOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"https://localhost:5001/calculate?arg1=4&operation=multiply&arg2=123").GetAwaiter().GetResult();            
            return response.ToString();
        }

        
    }
}