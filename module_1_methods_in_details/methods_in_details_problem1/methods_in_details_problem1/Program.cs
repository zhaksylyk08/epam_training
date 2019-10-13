using System;

namespace methods_in_details_problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = -255.255;
            string ans = ConvertDoubleToIEEE754(num);
            Console.WriteLine(ans);
        }

        public static string ConvertDoubleToIEEE754(double num) {
            string mantissa = String.Empty;  // mantissa - 52 bits
            string ans = String.Empty;
            string exponent = String.Empty;
            int exp = 0, biasedExp = 0;          // biasedExp = 1023 + exp;
            int intPart = (int)num;
            double remPart = num - intPart;
            while (intPart > 1) {  // for mantissa 
                mantissa += intPart % 2;
                exp++;
                intPart /= 2;
            }
            mantissa += "1";
         
            while (remPart < 1) {
                remPart *= 2;
                mantissa += (int)remPart;
            }
            biasedExp = 1023 + exp;     // for exponent
            while (biasedExp > 1) {
                exponent += biasedExp % 2;
                biasedExp /= 2;
            }

            if (num > 0)
                ans += "0";
            else
                ans += "1";
            ans += biasedExp;
            ans += mantissa;
            int addZeroNums = 52 - mantissa.Length;
            while (addZeroNums < 52) {
                ans += "0";
                addZeroNums++;
            }

            return ans;
        }

       
    }
}
