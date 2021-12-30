using System.Linq.Expressions;
using System.Threading.Tasks;
using hw9.Calculator;

namespace hw9.Calculator
{
    public class Calculator: Decorator
    {
        public string Input { get; set; }
        
        public override string CalculateNew(Expression input)
        {
            var result = new MyExpressionVisitor().Visit(input);
            return result.Result.ToString();
        }
        
        public Calculator(ICalculator calc) : base(calc)
        {
        }

        public Calculator() : base(null)
        {
        }
    }
}