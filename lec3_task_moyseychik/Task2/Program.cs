using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input values.
            int a, b;

            Console.Write("Enter A value, integer: ");
            a = int.Parse(Console.ReadLine());

            Console.Write("Enter B value, integer: ");
            b = int.Parse(Console.ReadLine());

            //Swap the values, if necessary.
            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            if (a < 0 && b < 0)
            {
                Console.WriteLine("There is no positive integers in the interval.");
                return;
            }

            if (a < 0)
            {
                a = 0;
            }

            //Find all the positive integers that has 4 ones.
            const int onesNumber = 4;

            Console.WriteLine($"All positive integers, that have {onesNumber} ones at binary presentation:");

            for (int i = a; i <= b; i++)
            {
                int counter = 0;

                for (int x = i; x > 0; x >>= 1)
                {
                    if (x % 2 != 0) 
                    {
                        counter++;
                    }

                    if (counter > onesNumber)
                    {
                        break;
                    }
                }

                if (counter == onesNumber)
                {
                    //The Convert class used only for demonstration.
                    Console.WriteLine($"{i} ({Convert.ToString(i, 2)})");
                }
            }
        }
    }
}
