using System;

namespace BinarySearchGenericImplementation
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int index = GenericBinarySearch(ref arr, 1);
            Console.WriteLine(index);
        }

        // iterative implementation of BinarySearch()
        public static int GenericBinarySearch<T>(ref T[] arr, T x) where T : IComparable<T>
        {
            int n = arr.Length;
            int l = 0, r = n - 1;

            while (l <= r) 
            {
                int mid = l + (r - l) / 2;
                if (x.Equals(arr[mid]))
                    return mid;
                else if (x.CompareTo(arr[mid]) > 0)
                    l = mid + 1;
                else
                    r = mid - 1;
            }

            return -1;
        }
    }
}
