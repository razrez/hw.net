using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hw9.MyExpressions.BinaryLogic
{
    public class MyBinaryVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var result = ProcessInParallel(node.Left, node.Right).Result;
            if (node.NodeType == ExpressionType.Add)
                return Expression.Add(Expression.Constant(result[0]), Expression.Constant(result[1]));
            if (node.NodeType == ExpressionType.Subtract)
                return Expression.Subtract(Expression.Constant(result[0]), Expression.Constant(result[1]));
            if (node.NodeType == ExpressionType.Multiply)
                return Expression.Multiply(Expression.Constant(result[0]), Expression.Constant(result[1]));
            if (node.NodeType == ExpressionType.Divide)
                return Expression.Divide(Expression.Constant(result[0]), Expression.Constant(result[1]));
            throw new ArgumentOutOfRangeException(nameof(node.NodeType));
        }

        private static async Task<double[]> ProcessInParallel(Expression left, Expression right)
        {
            return await Task.WhenAll(
                Task.Run(() => Expression.Lambda<Func<double>>(left).Compile().Invoke()),
                Task.Run(() => Expression.Lambda<Func<double>>(right).Compile().Invoke()));
        }
    }
}