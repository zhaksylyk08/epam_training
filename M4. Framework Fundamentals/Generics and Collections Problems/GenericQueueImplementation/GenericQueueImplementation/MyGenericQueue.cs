using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericQueueImplementation
{
    public class MyGenericQueue<T>: IEnumerable<T>
    {
        private T[] queue;
        private int size,
                    capacity,
                    front,
                    last;

        public int Count { get { return size; } }
        public MyGenericQueue(int size) 
        {
            queue = new T[size];
            front = last = 0;
            capacity = size;
            this.size = 0;
        }

        public void Enqueue(T data) 
        {
            // checking if array is full
            if (last == capacity)
            {
               var newQueue = new T[2 * capacity];
                for (int i = front; i < size; i++)
                    newQueue[i] = queue[i];
                queue = newQueue;
                capacity *= 2;
            }

            queue[last] = data;
            last++;
            size++;
        }

        public T Dequeue() 
        {
            if (size == 0)
                throw new OutOfMemoryException("MyGenericQueue is empty");

            T el = queue[front];
            front++;
            size--;

            return el;
        }

        public T Peek() => queue[front];

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = front; i < last; i++)
                yield return queue[i]; 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
