using System;
using System.Text;

namespace Problem2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string minorWords = "The In";
            string s = "THE WIND IN THE WILLOWS";

            //string s2 = "the quick brown fox";
            string result = ConvertToTitleCase(s, minorWords);
            Console.WriteLine(result);
        }

        public static string ConvertToTitleCase(string s) 
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("Empty or null string cannot be converted to title case");

            string[] words = s.Split(' ');
            var sb = new StringBuilder();

            for (int i = 0; i < words.Length; i++) 
            {
                string currentWord = words[i];
                for (int j = 0; j < words[i].Length; j++) 
                {
                    if (j == 0)
                        sb.Append(char.ToUpperInvariant(currentWord[j]));
                    else
                        sb.Append(char.ToLowerInvariant(currentWord[j]));
                }
                if (i < words.Length - 1)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public static string ConvertToTitleCase(string s, string minorWords) {

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(minorWords))
                throw new ArgumentException("Empty or null string cannot be converted to title case");

            var sb = new StringBuilder();
            string[] words = s.Split(' ');
            for (int i = 0; i < words.Length; i++) 
            {
                string currentWord = words[i];
                for (int j = 0; j < currentWord.Length; j++) 
                {
                    if (i == 0 && j == 0)
                        sb.Append(char.ToUpperInvariant(currentWord[j]));
                    else 
                    {
                        if (minorWords.IndexOf(currentWord, StringComparison.InvariantCultureIgnoreCase) > -1)
                            sb.Append(char.ToLowerInvariant(currentWord[j]));
                        else 
                        {
                            if (j == 0)
                                sb.Append(char.ToUpperInvariant(currentWord[j]));
                            else
                                sb.Append(char.ToLowerInvariant(currentWord[j]));
                        }
                    }
                }
                if (i < words.Length - 1)
                    sb.Append(' ');
            }


            return sb.ToString();
        }
    }
}
