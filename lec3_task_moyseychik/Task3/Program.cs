using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input values.
            Console.Write("Enter first 9 IBSN digits: ");
            string ibsn = Console.ReadLine();

            //Count control sum.
            int weight = 10, checksum = 0;

            foreach (char c in ibsn)
            {
                int digit = c - '0';
                checksum += digit * weight--;
            }

            //Count the last digit and output result.
            int mod = checksum % 11;

            if (mod == 0)
            {
                mod = 11;
            }

            int d10 = 11 - mod;
            char last = (d10 == 10) ? 'X' : (char)(d10 + '0');

            Console.WriteLine(ibsn + last);
        }
    }
}
