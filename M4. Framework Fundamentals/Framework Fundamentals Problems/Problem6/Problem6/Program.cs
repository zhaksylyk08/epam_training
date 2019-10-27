using System;
using System.Numerics;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
    
        }

        public static string AddTwoBigNumbers(string bigNumber1, string bigNumber2) 
        {
            BigInteger num1 = 0, num2 = 0, res = 0;
            BigInteger.TryParse(bigNumber1, out num1);
            BigInteger.TryParse(bigNumber2, out num2);
            res = num1 + num2;

            return res.ToString();
        }
    }
}
