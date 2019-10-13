using System;

namespace basic_coding_problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = { 2.0, 3.0, 3.0, 4.0, 1.0 };
            int n = arr.Length;
            int index = FindEqualSumsIndex(ref arr, n);
            Console.WriteLine(index);
        }

        public static int FindEqualSumsIndex(ref double[] arr, int n) { // searches index of elements for which
                                                                      // sum of left and rights elements are equal
            int index = -1;
            double leftSum = 0, rightSum = 0, totalSum = 0;
            for (int i = 0; i < n; i++)
                totalSum += arr[i];
            for (int i = 0; i < n; i++) {
                rightSum = totalSum - arr[i];
                if (leftSum == rightSum)
                    index = i;
                leftSum += arr[i];
            }

            return index;
        }
    }
}
