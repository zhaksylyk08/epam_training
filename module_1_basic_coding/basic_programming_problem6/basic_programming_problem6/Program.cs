using System;
using System.Collections.Generic;

namespace basic_programming_problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 7, 1, 2, 3, 4, 6, 7, 68, 69, 70, 13, 17 };
            int digit = 5;
            List<int> filteredList = FilterDigit(ref arr, digit);
            if (filteredList.Count == 0)
                Console.WriteLine("There are no numbers with {0} digit", digit);
            else
                foreach (int num in filteredList)
                    Console.Write("{0} ", num);


        }

        public static bool hasDigit(int num, int digit) {
            while (num > 0) {
                int rem = num % 10;
                if (rem == digit)
                    return true;
                num /= 10;
            }
            return false;
        }
        public static List<int> FilterDigit(ref int[] arr, int digit) {
            List<int> filteredList = new List<int>();
            for (int i = 0; i < arr.Length; i++) { 
                if(hasDigit(arr[i], digit))
                    filteredList.Add(arr[i]);
            }
            return filteredList;
        }
    }
}
