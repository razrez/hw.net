using System;
using System.Linq;

namespace Homework1
{
    internal static class Parser
    {
        private static readonly string[] ExpectedOperation = new[]
        {
            "+",
            "-",
            "*",
            $"/"
        };

        public static int TryToParse(string[] args, out int val1, out string operation, out int val2)
        {
            var isVal1Int = int.TryParse(args[0], out val1);
            operation = args[1];
            var isVal2Int = int.TryParse(args[2], out val2);

            if (!isVal1Int || !isVal2Int) //если val1 или val2 не int
            {
                Console.WriteLine($"{args[0]}{args[1]}{args[2]} is not a valid calculation syntax");
                return 1;
            }

            if (!ExpectedOperation.Contains(operation)) //если неверная операция
            {
                Console.WriteLine(
                    $"{args[0]}{args[1]}{args[2]} is not a valid calculation syntax. "
                    + $"Supported operations are "
                    + $"{ExpectedOperation.Aggregate((c, n) => $"{c} {n}")}");
                return 2;
            }

            return 0;
        }
    }

    internal static class Program
    {
        public static int  Main(string[] args)
        {
            var parseRes =  Parser.TryToParse(args, out var val1, 
                out var operation, out var val2);
            
            if (parseRes != 0) return parseRes;

            var result = Calculator.Calculate(val1, operation, val2);

            Console.WriteLine($"{args[0]}{args[1]}{args[2]}={result}");
            return 0;
        }
    }
}