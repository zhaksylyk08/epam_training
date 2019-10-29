using System;
using System.Collections.Generic;

namespace ReversePolishCalculatorImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "5 1 2 + 4 * + 3 -";
            int result = ReversePolishCalculator(expression);
            Console.WriteLine(result);
        }

        public static int ReversePolishCalculator(string expression)
        {
            var stack = new Stack<int>();
            string[] arr = expression.Split(' ');
            int result = 0;

            foreach (string s in arr)
            {
                int num;
                bool hasConverted = int.TryParse(s, out num);
                if (hasConverted)
                    stack.Push(num);
                else 
                {
                    int firstNum = stack.Pop();
                    int secondNum = stack.Pop();
                    switch (s) 
                    {
                        case "+":
                            result = firstNum + secondNum;
                            break;
                        case "-":
                            result = secondNum - firstNum;
                            break;
                        case "*":
                            result = firstNum * secondNum;
                            break;
                        case "/":
                            result = secondNum / firstNum;
                            break;
                        default:
                            break;
                    }

                    stack.Push(result);
                }
            }
            return result;
        }
    }
}
