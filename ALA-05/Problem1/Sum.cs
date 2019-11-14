using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem1
{
    public class Sum
    {
        private int GetSumOfRange(int n, CancellationToken token)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("The operation is cancelled");
                    return -1;
                }
                sum += i;
                Thread.Sleep(1000);
            }

            return sum;
        }

        public async void GetSumOfRangeAsync(int n, CancellationToken token)
        {
            if (token.IsCancellationRequested) 
            {
                Console.WriteLine("The operation is cancelled");
                return;
            }
            int x = await Task.Run(() => GetSumOfRange(n, token));
            //Thread.Sleep(5000);
            if(x > -1)
                Console.WriteLine(x);
        }
    }
}
