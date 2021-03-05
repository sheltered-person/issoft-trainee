using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackOfInts = new();

            //Overflows the stack for demostration of control.
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    stackOfInts.Push(i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            //Demostration of Reverse extension and it effect on the initial stack.
            Console.WriteLine($"Initial stack:\n{stackOfInts}\n");
            Console.WriteLine($"Reversed stack:\n{stackOfInts.Reverse()}\n");

            try
            {
                int element = stackOfInts.Pop();
                Console.WriteLine($"Last element of the initial stack: {element}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
