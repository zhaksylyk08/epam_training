using System;
using System.Linq;
using System.Collections.Generic;
namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            // for simplifications I used dictionary 
            var testResults = new Dictionary<string, double>();
            testResults.Add("Nanny", 23);
            testResults.Add("Becky", 36);
            testResults.Add("Ashley", 45);

            var selectedStudents = from i in testResults
                                   where i.Value > 30
                                   select i;

            foreach (var i in selectedStudents)
                Console.WriteLine("Student: {0}, test score = {1}", i.Key, i.Value);
        }
    }
}
