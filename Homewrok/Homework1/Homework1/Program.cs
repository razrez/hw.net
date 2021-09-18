using System;
using System.Linq;

namespace Homework1
{
    internal static class Program
    {
        private static string[] ExpectedOperation = new[]
        {
            "+",
            "-",
            "*",
            "/"
        };
            
        public static void Main(string[] args)
        {
            var result = 0;
            var val1 = int.Parse(args[0]);
            
            var operation = args[1];
            var val2 = int.Parse(args[2]);
            result = operation switch
            {
                "+" => val1 + val2,
                "-" => val1 - val2,
                "*" => val1 * val2,
                "/" => val1 / val2,
                _ => result
            };

            Console.WriteLine($"{args[0]}{args[1]}{args[2]}={result}");
        }
    }
}