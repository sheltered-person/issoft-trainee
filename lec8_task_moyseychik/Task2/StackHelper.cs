using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class StackHelper
    {
        /* Maybe it is better to clone initial stack to not modify it.
           To do this we can and Clone method to IStack interface or inherrit this interface
           from IClonable. */

        public static IStack<T> Reverse<T>(this IStack<T> stack) 
            where T : struct
        {
            if (stack is null)
            {
                throw new ArgumentNullException("Error: stack object was null.");
            }

            Stack<T> copyStack = stack.Clone() as Stack<T>,
                newStack = new Stack<T>();

            while (!copyStack.IsEmpty())
            {
                newStack.Push(copyStack.Pop());
            }

            return newStack;
        }
    }
}
