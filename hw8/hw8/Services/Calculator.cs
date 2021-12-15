using System.Globalization;

namespace hw8.Services
{
    public class Calculator : ICalculateService
    {
        string ICalculateService.Calculate(int val1, string operation, int val2)
        {
            CultureInfo invC = CultureInfo.InvariantCulture;
            var result = 0;
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