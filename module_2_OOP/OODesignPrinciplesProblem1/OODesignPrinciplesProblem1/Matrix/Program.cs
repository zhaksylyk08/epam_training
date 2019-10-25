using System;
using System.Collections.Generic;

namespace OODesignPrinciplesProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new Matrix(2, 3);
            var test2 = new Matrix(2, 3);
            int counter1 = 1, counter2 = 7;
            for (int i = 0; i < test1.NumberOfRows; i++) 
            {
                for (int j = 0; j < test1.NumberOfColumns; j++) 
                {
                    test1[i, j] = counter1;
                    counter1++;
                }
            }
            Console.WriteLine("First Matrix:");
            Console.WriteLine(test1);
            for (int i = 0; i < test2.NumberOfRows; i++)
            {
                for (int j = 0; j < test2.NumberOfColumns; j++)
                {
                    test2[i, j] = counter2;
                    counter2++;
                }
            }
            Console.WriteLine("Second Matrix:");
            Console.WriteLine(test2);
            var result = test1 + test2;
            Console.WriteLine("sum of two Matrix objects:");
            Console.WriteLine(result);
        }
    }
}
