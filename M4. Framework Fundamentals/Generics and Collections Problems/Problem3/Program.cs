using System;
using System.Collections;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 7;
            foreach (int i in CountFibonacciNumbers(n))
                Console.Write("{0} ", i);

        }

        public static IEnumerable CountFibonacciNumbers(int n) 
        {
            int[] arr = new int[n];
            arr[0] = 0;     // first element
            arr[1] = 1;     // second element

            for (int i = 2; i < n; i++) 
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

            for (int i = 0; i < n; i++)
                yield return arr[i];
        }
    }
}
