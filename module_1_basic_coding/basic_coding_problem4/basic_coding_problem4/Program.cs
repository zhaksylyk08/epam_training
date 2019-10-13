using System;

namespace basic_coding_problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Happy";
            string s2 = "baby";
            string ans = String.Empty;
            if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
                Console.WriteLine("The strings cannot be empty or null!");
            else
                ans = AddTwoStrings(s1, s2);
            Console.WriteLine(ans);
        }

        public static string AddTwoStrings(string s1, string s2) { // concatenates two strings removing 
            string concatString = String.Empty;                     // duplicate chars
            for (int i = 0; i < s1.Length; i++) {
                char ch = s1[i];
                if (concatString.IndexOf(ch) < 0)
                    concatString += ch;
            }

            for (int j = 0; j < s2.Length; j++) {
                char ch = s2[j];
                if (concatString.IndexOf(ch) < 0)
                    concatString += ch;
            }

            return concatString;
        }
    }
}
