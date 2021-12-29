using System.Linq.Expressions;

namespace hw9.Services
{
    public class CalculatorDecorator: ICalculator
    {
        protected ICalculator _calculator;

        protected CalculatorDecorator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public virtual double? Calculate(Expression node)
        {
            return _calculator?.Calculate(node);
        }
    }
}