using System;
using System.Numerics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Task1
{
    //Static functions to work with BigIntegers.
    public static class FactorizeLib
    {
        private static readonly int _minValue = 2;

        private static readonly int _capacity = 15;

        private static Random _random = new();

        //Generate positive BigInteger from byte array of required length.
        public static BigInteger RandomPositiveBigInteger(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length of BigInteger in bytes" +
                    " can't be negative or zero.");
            }

            byte[] data = new byte[length];
            _random.NextBytes(data);

            BigInteger n = new(data);
            return n > 0 ? n : -n;
        }

        //Factorization of number by divisors enumeration.
        public static List<BigInteger> Factorization(BigInteger n)
        {
            if (n < _minValue)
            {
                throw new ArgumentException($"Number to factorize was less than {_minValue}.");
            }

            List<BigInteger> factors = new(_capacity);

            while (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }

            for (BigInteger i = 3; n > 1; i += 2)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }

            return factors;
        }

        //Async version of factorization based on Thread.
        public static Task<List<BigInteger>> FactorizationAsync(BigInteger n)
        {
            TaskCompletionSource<List<BigInteger>> tcSource = new();
            new Thread(CalculateFactorization).Start();
            return tcSource.Task;

            void CalculateFactorization()
            {
                try
                {
                    List<BigInteger> factors = Factorization(n);
                    tcSource.SetResult(factors);
                }
                catch (Exception ex)
                {
                    tcSource.SetException(ex);
                }
            }
        }

        //Async GCD counting by getting all factors of numbers
        //and looking for the intersection.
        public static async Task<BigInteger> GcdAsync(BigInteger a, BigInteger b)
        {
            List<BigInteger> factorsA = await FactorizationAsync(a).ConfigureAwait(false),
                factorsB = await FactorizationAsync(b).ConfigureAwait(false);

            BigInteger gcd = BigInteger.One;

            IEnumerable<BigInteger> intersection
                = factorsA.Intersect(factorsB);

            if (intersection.Count() != 0)
            {
                gcd = intersection.Max();
            }

            return gcd;
        }
    }
}
