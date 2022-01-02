using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hw9.Calculator
{
    public class MyExpressionVisitor 
    {
        public async Task<double> Visit(Expression node)
        {
            return await VisitNode((dynamic) node);
        }

        private async Task<double> VisitNode(ConstantExpression node)
        {
            return await Task.FromResult((double) node.Value);
        }

        private async Task<double> VisitNode(BinaryExpression node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            Task.WaitAll(left, right);

            var result = node.NodeType switch
            {
                ExpressionType.Add => left.Result + right.Result,
                ExpressionType.Subtract => left.Result - right.Result,
                ExpressionType.Multiply => left.Result * right.Result,
                ExpressionType.Divide => left.Result / right.Result,
                _ => throw new ArgumentOutOfRangeException(nameof(node.NodeType))
            };

            return result;
        }
    }
}