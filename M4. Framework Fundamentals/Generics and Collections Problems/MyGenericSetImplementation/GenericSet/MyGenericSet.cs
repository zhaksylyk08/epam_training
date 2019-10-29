using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyGenericSetImplementation
{
    // the type argument must be reference type
    public class MyGenericSet<TKey>: IEnumerable<TKey> where TKey: class
    {
        private TKey[] hashTable;
        private int size,
                    capacity = 50;

        public int Count { get { return size; } }
        public MyGenericSet() 
        {
            hashTable = new TKey[capacity];
            size = 0;
        }

        public bool Add(TKey data) 
        {
            if (data == null)
                throw new ArgumentNullException("Key cannot be null");

            int index = hash(data);

            if (hashTable[index] == null)     // because set stores unique elements
            {
                hashTable[index] = data;
                size++;
                return true;
            }

            return false;
        }

        private int hash(TKey key) 
        {
            return (key.GetHashCode() & 0x7fffffff) % capacity;
        }

        public IEnumerator<TKey> GetEnumerator()
        {
            foreach (TKey key in hashTable)
                yield return key;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
