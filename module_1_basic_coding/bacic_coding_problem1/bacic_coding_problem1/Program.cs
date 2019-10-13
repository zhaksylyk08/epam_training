using System;

namespace bacic_coding_problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            // calling insertNumber()
            int numberSource = 15;
            int numberIn = 15;
            int i = 0;
            int j = 0;
            int ans = InsertNumber(numberSource, numberIn, i, j);
            Console.WriteLine(ans);
        }

        public static void ConverNumToArrOfBits(ref int[] remArray, int num) {
            int cur = 0;
            while (num > 1) {
                int rem = num % 2;
                remArray[cur] = rem;
                num /= 2;
                cur++;
            }
            if (num > 0)
                remArray[cur] = 1;
        }
        public static int InsertNumber(int numberSource, int numberIn, int i, int j) {
            int[] remArray1 = new int[32];   // for remainders of dividing numberSource in 2
            int[] remArray2 = new int[32];   // for remainders of dividing numberIn in 2
            int ans = 0;
            ConverNumToArrOfBits(ref remArray1, numberSource);
            ConverNumToArrOfBits(ref remArray2, numberIn);
            int cur = 0;
            while (i <= j) {      // inserting bits of numberIn into numberSource from i to j positions
                if (cur < remArray2.Length)
                    remArray1[i] = remArray2[cur];
                else 
                    remArray1[i] = 0;
                cur++;
                i++;
            }
            for (int m = 0; m < remArray1.Length; m++)   // calculating output number from arr of bits
                ans += remArray1[m] * (int)Math.Pow(2, m);
            
            return ans;
        }
    }
}
