using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace hw9.MyExpressions.BinaryLogic
{
    public static class MyExpressionTree
    {
        public static Expression ConvertToBinaryTree(string input)
        {
            var stack = new Stack<Expression>();
            foreach (var i in Parser.ToPostfix(input).Split("%20"))
            {
                if (double.TryParse(i, out var variable))
                    stack.Push(Expression.Constant(variable));
                else
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    BinaryExpression node;
                    if (i == "+")
                        node = Expression.Add(left, right);
                    else if (i == "-")
                        node = Expression.Subtract(left, right);
                    else if (i == "*")
                        node = Expression.Multiply(left, right);
                    else if (i == "/")
                        node = Expression.Divide(left, right);
                    else
                        throw new ArgumentOutOfRangeException(nameof(i));

                    stack.Push(node);
                }
            }
            return stack.Pop();
        }
    }
}