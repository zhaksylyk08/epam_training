using System;
using System.Globalization;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Customer("Jeffrey Richter", (decimal)1000000.95, "+1(425)555-0100");
            var test2 = new Customer("Jackie Chan", 123000055, "+1(000)456-112");
            Console.WriteLine(test);
            Console.WriteLine(test.ToString("C"));
            Console.WriteLine(test2.ToString("c"));
        }
    }
}
