using System;
using System.Text;

namespace Task2
{
    public class Stack<T> : IStack<T>
        where T : struct
    {
        private const int capacity = 100;

        private readonly T[] data = new T[capacity];
        private int index;

        //Standard stack interface.
        public bool IsEmpty()
        {
            return index == 0;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Error: stack is empty.");
            }

            return data[--index];
        }

        public void Push(T element)
        {
            if (index == capacity)
            {
                throw new StackOverflowException("Error: stack is full.");
            }

            data[index++] = element;
        }

        //ToString override for convenient stack representation.
        public override string ToString()
        {
            StringBuilder stack = new StringBuilder();

            for (int i = index - 1; i >= 0; i--)
            {
                stack.Append($"{data[i]}\n");
            }

            return stack.ToString();
        }

        public virtual object Clone()
        {
            Stack<T> newStack = new();

            foreach (T element in data)
            {
                newStack.Push(element);
            }

            return newStack;
        }
    }
}
