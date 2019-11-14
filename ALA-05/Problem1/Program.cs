using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var cts2 = new CancellationTokenSource();
            var token2 = cts2.Token;

            int n, n2;

            Console.WriteLine("Enter integer number:");
      
            if (Int32.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                var s = new Sum();
                s.GetSumOfRangeAsync(n, token);
            }

            if (Int32.TryParse(Console.ReadLine(), out n2) && n2 > 0)
            {
                cts.Cancel();
                var s2 = new Sum();
                s2.GetSumOfRangeAsync(n2, token2);
            }

            Console.ReadKey();
        }


    }
}
