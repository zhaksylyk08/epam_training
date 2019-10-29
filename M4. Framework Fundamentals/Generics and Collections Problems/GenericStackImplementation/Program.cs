using System;

namespace GenericStackImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new MyGenericStack<int>();
            test.Push(1);
            test.Push(2);
            test.Push(3);
            //test.Pop();
            foreach (int i in test)
                Console.Write("{0} ", i);
        }
    }
}
