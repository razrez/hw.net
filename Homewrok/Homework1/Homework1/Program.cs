using System;
using System.Linq;

namespace Homework1
{
    internal static class Program
    {
        private static readonly string[] ExpectedOperation = new[]
        {
            "+",
            "-",
            "*",
            $"/"
        };
            
        public static int  Main(string[] args)
        {
            var isVal1Int = int.TryParse(args[0], out var val1);
            var operation = args[1];
            var isVal2Int = int.TryParse(args[2], out var val2);
            
            if (!isVal1Int || !isVal2Int)
            {
                Console.WriteLine($"{args[0]}{args[1]}{args[2]} is not a valid calculation syntax");
                return 1;
            }

            if (!ExpectedOperation.Contains(operation))
            {
                Console.WriteLine(
                    $"{args[0]}{args[1]}{args[2]} is not a valid calculation syntax. "
                    + $"Supported operations are "
                    + $"{ExpectedOperation.Aggregate((c, n) => $"{c} {n}")}");
                return 2;
            }

            var result = Calculator.Calculate(val1, operation, val2);

            Console.WriteLine($"{args[0]}{args[1]}{args[2]}={result}");
            return 0;
        }

        
    }
}