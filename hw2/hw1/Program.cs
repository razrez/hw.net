using System;

namespace hw1
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var parseRes = ParserIL.TryToParse(args, out var val1,
                out var operation, out var val2); //test ParserIL

            if (parseRes != 0) return parseRes;

            var result = CalculatorIL.Calculate(val1, operation, val2);
            
            Console.WriteLine($"{args[0]}{args[1]}{args[2]}={result}");
            return 0;
        }
    }
}