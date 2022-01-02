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
        public void FsharpMinusOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculate?arg1=549&operation=minus&arg2=32").GetAwaiter().GetResult();
        }

        [Benchmark]
        public void FsharpPlusOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculate?arg1=5050&operation=plus&arg2=1").GetAwaiter().GetResult();
        }

        [Benchmark]
        public void FsharpMultiplyOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculate?arg1=225&operation=multiply&arg2=5").GetAwaiter().GetResult();            
        }

        [Benchmark]
        public void FsharpDivideOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculate?arg1=100&operation=divide&arg2=10").GetAwaiter().GetResult();            
        }
                
        [Benchmark]
        public void CsharpMinusOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/subtract?arg1=549&arg2=32").GetAwaiter().GetResult();
        }

        [Benchmark]
        public void CsharpPlusOperation()
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
        public void CsharpDivideOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/divide?arg1=100&arg2=10").GetAwaiter().GetResult();
        }

        
    }
}