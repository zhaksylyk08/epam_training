using System;
using System.Text;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "The greatest victory is that which requires no battle";
            string res = ReverseWords(s);
            Console.WriteLine(res);
        }

        public static string ReverseWords(string s) 
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("string cannot be null or empty");

            string[] words = s.Split(' ');
            var sb = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--) 
            {
                sb.Append(words[i]);
                if (i != 0)
                    sb.Append(" ");
            }

            return sb.ToString();
                
        }
    }
}
