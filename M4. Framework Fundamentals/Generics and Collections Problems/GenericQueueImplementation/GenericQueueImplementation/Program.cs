using System;

namespace GenericQueueImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new MyGenericQueue<int>(5);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Enqueue(6);
            test.Dequeue();
            test.Enqueue(7);
            foreach (int i in test)
                Console.Write("{0} ", i);
        }
    }
}
