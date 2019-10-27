using System;
using System.Collections.Generic;

namespace Problem4
{
    public class Program
    {
        static void Main(string[] args)
        {
            string s = "AAAABBBCCDAABBB";
            var res = UniqueInOrder(s);
            Console.Write("size = {0}", res.Count);
            foreach (char ch in res)
                Console.Write("{0} ", ch);
        }

        public static List<int> UniqueInOrder(string s)
        {
            var st = new Stack<char>();
            var res = new List<int>();

            foreach (char ch in s) 
            {
                if (st.Count < 1)
                    st.Push(ch);

                if (st.Peek() != ch)
                    st.Push(ch);
                else 
                {
                    while (st.Count > 0 && st.Peek() == ch)
                        st.Pop();
                }
            }

            while (st.Count > 0)  // adding to list
            {
                res.Add(st.Peek());
                st.Pop();
            }

            res.Reverse();

            return res;
        }
    }
}
