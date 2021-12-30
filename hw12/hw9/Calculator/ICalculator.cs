using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hw9.Calculator
{
    public interface ICalculator
    {
        public string Calculate(Expression node);
        public string CalculateNew(Expression input);
    }
}