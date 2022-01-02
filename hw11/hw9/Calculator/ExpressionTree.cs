using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace hw9.Calculator
{
    public static class ExpressionTree
    {
        public static Expression ConvertToBinaryTree(string input)
        {
            var stack = new Stack<Expression>();
            foreach (var i in Parser.ToPostfix(input).Split( " "))
            {
                if (double.TryParse(i, out var variable))
                    stack.Push(Expression.Constant(variable));
                else
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    var node = i == "+" ? Expression.Add(left, right) :
                        i == "-" ? Expression.Subtract(left, right) :
                        i == "*" ? Expression.Multiply(left, right) :
                        i == "/" ? Expression.Divide(left, right) : throw new ArgumentOutOfRangeException(nameof(i));
                    stack.Push(node);
                }
            }
            return stack.Pop();
        }
    }
}