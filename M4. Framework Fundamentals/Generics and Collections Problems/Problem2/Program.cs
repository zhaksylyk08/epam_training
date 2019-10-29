using System;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = @"C:\epam_lab\epam_training\M4. Framework Fundamentals\Generics and Collections Problems\test.txt";
            string word = "Canada";
            int frequency = FrequencyOfWord(s, word);
            Console.WriteLine(frequency);
        }

        public static int FrequencyOfWord(string filePath, string word)
        {
            int frequency = 0;
            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string s in lines)
            {
                int location = s.IndexOf(word, 0, StringComparison.InvariantCultureIgnoreCase);
                while (location < s.Length && location > -1)
                {
                    frequency++;

                    int newStart = location + word.Length + 1;
                    if (newStart >= s.Length) break;
                    location = s.IndexOf(word, newStart, StringComparison.InvariantCultureIgnoreCase);
                }
            }

            return frequency;
        }
    }
}
