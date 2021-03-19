using System;

namespace Task1
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        public int Index { get; }

        public T OldValue { get; }

        public T NewValue { get; }

        public ElementChangedEventArgs(int index, T old, T @new)
        {
            (Index, OldValue, NewValue) = (index, old, @new);
        }

        public override string ToString()
        {
            return $"Value on {Index}x{Index} position was changed!\n" +
                $"\tOld value: {OldValue}\n" +
                $"\tNew value: {NewValue}\n";
        }
    }
}
