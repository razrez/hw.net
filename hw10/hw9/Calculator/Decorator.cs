using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;

namespace hw9.Calculator
{
    public class Decorator: ICalculator
    {
        protected ICalculator _calculator;

        protected Decorator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public virtual string Calculate(Expression node)
        {
            return _calculator?.Calculate(node);
        }

        public virtual string CalculateNew(Expression input)
        {
            return _calculator.CalculateNew(input);
        }

    }
}