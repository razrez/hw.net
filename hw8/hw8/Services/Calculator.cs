using System.Globalization;

namespace hw8.Services
{
    public class Calculator : ICalculateService
    {
        public string Calculate(double val1, string operation, double val2)
        {
            var invC = CultureInfo.InvariantCulture;
            double result = 0;
            result = operation switch
            {
                "plus" => val1 + val2,
                "minus" => val1 - val2,
                "multiply" => val1 * val2,
                "divide" => val1 / val2,
                _ => result
            };
            return result.ToString(invC);
        }
    }
}