using System.Linq.Expressions;

namespace hw9.Services
{
    public interface ICalculator
    {
        public double? Calculate(Expression node);
    }
}