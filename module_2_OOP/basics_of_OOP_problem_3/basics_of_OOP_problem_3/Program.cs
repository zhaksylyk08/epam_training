using System;
using System.Collections.Generic;

namespace basics_of_OOP_problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> coeff = new List<int> { 7, 8, 9, 0, 2 };
            Polynomial pol = new Polynomial(4, coeff);
            string s = pol.ToString();
            Console.WriteLine(s);
        }
    }
}
