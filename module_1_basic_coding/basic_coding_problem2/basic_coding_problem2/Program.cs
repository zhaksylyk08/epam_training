using System;

namespace basic_coding_problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 7, 2, 1, 0, -3 };
            int n = arr.Length;
            int max = FindMaxRecurs(ref arr, n);
            Console.WriteLine(max);
        }

        public static int FindMaxRecurs(ref int[] arr, int n ) {  // recursive searching max in array
            if (n == 1)
                return arr[0];
            else
                return Math.Max(arr[n - 1], FindMaxRecurs(ref arr, n - 1));
        }
    }
}
