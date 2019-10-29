using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericStackImplementation
{
    class MyGenericStack<T>: IEnumerable<T>
    {
        private T[] stack;
        private int size,
                    capacity = 10,
                    current;

        public int Count { get { return size; } }

        public MyGenericStack() 
        {
            stack = new T[capacity];
            size = 0;
            current = -1;
        }
        public void Push(T data) 
        {
            if (size == capacity) 
            {
                var newStack = new T[capacity * 2];
                for (int i = 0; i < size; i++)
                    newStack[i] = stack[i];
                stack = newStack;

                capacity *= 2;
            }

            current++;
            stack[current] = data;
            
            size++;
        }

        public T Pop() 
        {
            T el = stack[current];
            current--;
            size--;

            return el;
        }

        public T Peek() => stack[current];

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = size - 1; i >= 0; i--)
                yield return stack[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
