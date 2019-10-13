using System;

namespace creating_types_problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.04100625;
            int n = 4;
            double accuracy = 0.0001;
            double ans = FindNthRoot(a, n, accuracy);
            Console.WriteLine(ans);
        }

        public static double FindNthRoot(double a, int n, double accuracy) {
            Random rand = new Random();
            double xPre = rand.Next(10);
            double delX = 2147483647;
            double xK = 0.0;
            // loop untill reaching the accuracy
            while (delX > accuracy) {
                // calculating cur value from prev using Newton's method
                xK = ((n - 1.0) * xPre + (double)a / Math.Pow(xPre, n - 1)) / (double)n;
                delX = Math.Abs(xK - xPre);
                xPre = xK;
            }

            return xK;
        }
    }
}
