using System.Linq.Expressions;
using System.Threading.Tasks;
using hw9.MyExpressions.BinaryLogic;

namespace hw9.Services
{
    public class Calculator:CalculatorDecorator
    {
        public Calculator(ICalculator calculator) : base(calculator){}
        public Calculator() : base(null){}
        
        public string Expr { get; set; }
        
        public virtual async Task<double> Calculate(Expression input)
        {
            var result = await (new MyBinaryVisitor().Visit(input));
            return result;
        }
        
    }
}