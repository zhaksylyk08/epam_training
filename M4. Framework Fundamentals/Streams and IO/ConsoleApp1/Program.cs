using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"C:\epam_lab\epam_training\M4. Framework Fundamentals\Streams and IO\SourceText.txt";
            string path2 = @"C:\epam_lab\epam_training\M4. Framework Fundamentals\Streams and IO\DestinationText.txt";

            var fc = new FileCopy(path1, path2);
            long cnt = fc.CopyUsingBufferedStream();
            Console.WriteLine("number of {0}", cnt);

            Console.ReadKey();
        }
    }
}
