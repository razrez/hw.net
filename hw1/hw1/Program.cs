using System;

namespace hw1
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var parseRes = Parser.TryToParse(args, out var val1,
                out var operation, out var val2);

            if (parseRes != 0) return parseRes;

            var result = Calculator.Calculate(val1, operation, val2);

            Console.WriteLine($"{args[0]}{args[1]}{args[2]}={result}");
            return 0;
        }
    }
}