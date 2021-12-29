using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace hw9.MyExpressions
{
    public static class Parser
    {
        private static readonly Regex _inputSplit = new ("(?<=[-+*/\\(\\)])|(?=[-+*/\\(\\)])");
        private static readonly Regex _operand = new ("[0-9]+");
        private static readonly Dictionary<string, int> _priorityOperator = new()
        {
            {"(", 1},
            {")", 1},
            {"-", 2},
            {"+", 2},
            {"*", 3},
            {"/", 3}
        };

        public static string ToPostfix(string expression)
        {
            var operators = new Stack<string>();
            var postfix = new Stack<string>();
            foreach (var i in _inputSplit.Split(expression.Replace(" ", " ")))
            {
                switch (i)
                {
                    case "": continue;
                    case "(": operators.Push(i); break;
                    default:
                    {
                        if (_operand.IsMatch(i))
                        {
                            postfix.Push(i);
                        }
                        else if (i == ")")
                        {
                            while (operators.Peek() != "(")
                            {
                                var op = operators.Pop();
                                var first = postfix.Pop();
                                var second = postfix.Pop();
                                postfix.Push(second + " " + first + " " + op);
                            }

                            operators.Pop();
                        }
                        else
                        {
                            while (operators.Count > 0 && operators.Peek() != "(" &&
                                   _priorityOperator[i] <= _priorityOperator[operators.Peek()])
                            {
                                var op = operators.Pop();
                                var first = postfix.Pop();
                                var second = postfix.Pop();
                                postfix.Push(second + " " + first + " " + op);
                            }

                            operators.Push(i);
                        }

                        break;
                    }
                }
            }

            while (operators.Count > 0)
            {
                var op = operators.Pop();
                var first = postfix.Pop();
                var second = postfix.Pop();
                postfix.Push(second + " " + first + " " + op);
            }

            return postfix.Pop();
        }

        private static void PostfixPush(Stack<string> operators, Stack<string> postfix)
        {
            var op = operators.Pop();
            var first = postfix.Pop();
            var second = postfix.Pop();
            postfix.Push(second + " " + first + " " + op);
        }
    }
}