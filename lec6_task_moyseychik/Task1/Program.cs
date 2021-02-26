using System;

namespace Task1
{
    internal class Program
    {
        //For printing some testing info.
        static void PrintDescription(DiagonalMatrix matrix)
        {
            Console.WriteLine(matrix);

            Console.WriteLine($"Matrix size: {matrix.Size}");
            Console.WriteLine($"Track method: {matrix.Track()}\n");
        }

        static void Main(string[] args)
        {
            //Init some matrices for testing.
            DiagonalMatrix[] matrices =
            {
                new(),
                new(1, 2, 3),
                new(1, 2, 3),
                new(-2, 4)
            };

            for (int i = 0; i < matrices.Length; i++)
            {
                Console.WriteLine($"Matrix #{i}");
                PrintDescription(matrices[i]);
            }

            //Check for the equality 
            for (int i = 0; i < matrices.Length; i++)
            {
                for (int j = 0; j < matrices.Length; j++)
                {
                    if (i != j && matrices[i].Equals(matrices[j])) 
                    {
                        Console.WriteLine($"The equality found! Matrices #{i} and #{j} are equal.");
                    }
                }
            }

            //Demostration of indexer work.
            Console.WriteLine("\nIndexer testing:\n");

            DiagonalMatrix diag = matrices[1];
            PrintDescription(diag);

            diag[0, 0] = -11;
            diag[1, 2] = 7;
            diag[-1, -1] = 10;
            diag[4, 4] = -3;

            PrintDescription(diag);

            //Demonstration of addition extension method.
            Console.WriteLine("\nAddition of matrices:");

            Console.WriteLine(matrices[1]);
            Console.WriteLine(matrices[3]);
            Console.WriteLine(matrices[1].Add(matrices[3]));
        }
    }
}
