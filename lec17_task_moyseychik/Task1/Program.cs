using System;
using System.Numerics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        internal static void PrintFactorsList(List<BigInteger> factors)
        {
            foreach (BigInteger factor in factors)
            {
                Console.WriteLine(factor);
            }
        }

        internal static void Main(string[] args)
        {
            const int byteLength = 4;

            BigInteger a, b;
            List<BigInteger> factors;
            Task<List<BigInteger>> factorsAsyncTask;

            try
            {
                a = FactorizeLib.RandomPositiveBigInteger(byteLength);
                b = FactorizeLib.RandomPositiveBigInteger(byteLength);

                Console.WriteLine($"A = {a}\n");

                factors = FactorizeLib.Factorization(a);
                factorsAsyncTask = FactorizeLib.FactorizationAsync(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
            Console.WriteLine("Sync A factorizing results:");
            PrintFactorsList(factors);

            try
            {
                Console.WriteLine("\nAsync A factorizing results:");
                PrintFactorsList(factorsAsyncTask.Result);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            BigInteger gcd;

            try
            {
                gcd = FactorizeLib.GcdAsync(a, b).Result;
                Console.WriteLine($"GCD of {a} and {b} = {gcd}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
