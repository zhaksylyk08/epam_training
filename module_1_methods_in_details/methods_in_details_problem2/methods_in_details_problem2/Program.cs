using System;

namespace methods_in_details_problem2
{
    class Program
    {
        delegate int Operation(int x, int y);
        static void Main(string[] args)
        {
            Operation del = FindGCDForTwoNums;
            int result = del.Invoke(10, 20);
            Console.WriteLine(result);
        }

        public static int FindGCDForTwoNums(int a, int b) {
            if (a == 0)
                return b;
            return FindGCDForTwoNums(b % a, a);
        }
        public static int FindGCD(params int[] nums) {
            int result = nums[0];
            for (int i = 1; i < nums.Length; i++) {
                result = FindGCDForTwoNums(nums[i], result);
            }

            return result;
        }
    }
}
