using System;

namespace Task2
{
    public interface IStack<T> : ICloneable where T: struct
    {
        void Push(T element);

        T Pop();

        bool IsEmpty();
    }
}
