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
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationTokenSource cts2 = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            CancellationToken token2 = cts2.Token;

            Console.WriteLine("Please, enter integer n:");
            int n = Int32.Parse(Console.ReadLine());
            GetSumOfRangeAsync(n, token);

            int n2 = Int32.Parse(Console.ReadLine());
            cts.Cancel();
            GetSumOfRangeAsync(n2, token2);
            //Console.ReadKey();
        }
        static void GetSumOfRange(int n, CancellationToken token) 
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Operation is cancelled");
                    return;
                }
                sum += i;
                Console.WriteLine("sum from 0 to {0} = {1}", i, sum);
                Thread.Sleep(3000);
            }
            Console.WriteLine("sum = {0}", sum);
        }
        static async void GetSumOfRangeAsync(int n, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;
            await Task.Run(() => GetSumOfRange(n, token));
        }
    }
}
