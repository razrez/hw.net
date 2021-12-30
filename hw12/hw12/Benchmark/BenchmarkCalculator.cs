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
        public void CsharpMinusOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/subtract?arg1=1449&arg2=1").GetAwaiter().GetResult();
        }

        [Benchmark]
        public void CsharpAddOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/add?arg1=5050&arg2=1").GetAwaiter().GetResult();
        }
        
        [Benchmark]
        public void CsharpMultiplyOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/multiply?arg1=225&arg2=5").GetAwaiter().GetResult();
        }

        [Benchmark]
        public void CsharpDivisionOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/divide?arg1=100&arg2=10").GetAwaiter().GetResult();
        }

        [Benchmark]
        public string FsharpMinusOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/subtract?arg1=1449&arg2=1").GetAwaiter().GetResult();
            return response.ToString();
        }

        [Benchmark]
        public string FsharpAddOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculator?arg1=5050&operation=add&arg2=1").GetAwaiter().GetResult();
            return response.ToString();
        }

        [Benchmark]
        public string FsharpMultiplyOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculator?arg1=225&operation=multiply&arg2=5").GetAwaiter().GetResult();            
            return response.ToString();
        }

        [Benchmark]
        public string FsharpDivisionOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculator?arg1=100&operation=divide&arg2=10").GetAwaiter().GetResult();            
            return response.ToString();
        }
    }
}