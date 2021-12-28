using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace hw9.MyExpressions
{
    public static class Parser
    {
        private static readonly Regex _inputSplit = new ("(?<=[-+*/\\(\\)])|(?=[-+*/\\(\\)])");
        private static readonly Regex _operand = new ("[0-9]+");
        
        private static readonly Dictionary<string, int> _PriorityOperator = new()
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
            expression.Replace("%20", "");
            foreach (var i in _inputSplit.Split(expression.Replace(" ", "+")))
            {
                switch (i)
                {
                    case "":
                        continue;
                    case "(":
                        operators.Push(i);
                        break;
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
                                PostfixPush(operators, postfix);
                            }

                            operators.Pop();
                        }
                        else
                        {
                            while (operators.Count > 0 && operators.Peek() != "(" &&
                                   _PriorityOperator[i] <= _PriorityOperator[operators.Peek()])
                            {
                                PostfixPush(operators, postfix);
                            }

                            operators.Push(i);
                        }

                        break;
                    }
                }
            }

            while (operators.Count > 0)
            {
                PostfixPush(operators, postfix);
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