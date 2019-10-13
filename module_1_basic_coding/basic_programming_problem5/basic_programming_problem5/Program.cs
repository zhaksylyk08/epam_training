using System;

namespace basic_programming_problem5
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = 10;
            int ans = FindNextBiggerNumber(num);
            Console.WriteLine(ans);
        }

        public static int FindNextBiggerNumber(int num) {  // reurn the closest bigger number with the same digits
            int nextBiggerNumber = -1;
            int curDigit = 0, prevDigit = 0, cur = 0, sum = 0;
            bool is_found = false;
            while (num > 0) {
                curDigit = num % 10;
                if (cur > 0)
                {
                    if (prevDigit > curDigit && is_found == false)
                    {
                        sum -= prevDigit * (int)Math.Pow(10, cur - 1);
                        sum += curDigit * (int)Math.Pow(10, cur - 1);
                        sum += prevDigit * (int)Math.Pow(10, cur);
                        is_found = true;
                    }
                    else
                        sum += curDigit * (int)Math.Pow(10, cur);
                }
                else
                    sum += curDigit * (int)Math.Pow(10, cur);

                cur++;
                prevDigit = curDigit;
                num /= 10;
            }
            if (is_found)
                nextBiggerNumber = sum;
            return nextBiggerNumber;
        }
    }
}
