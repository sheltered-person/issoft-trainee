using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Init matrix for testing.

            DiagonalMatrix<double> matrixOfDoubles;

            try
            {
                Console.WriteLine("Trying to init matrix with negative size:");
                matrixOfDoubles = new(-3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            matrixOfDoubles = new(5);

            matrixOfDoubles[0, 0] = 1.6;
            matrixOfDoubles[1, 1] = 13.0;
            matrixOfDoubles[2, 2] = -0.9;
            matrixOfDoubles[3, 3] = 7.0;

            Console.WriteLine($"\nMatrix #1: \n{matrixOfDoubles}");

            try
            {
                Console.WriteLine($"Value [2, 2]: {matrixOfDoubles[2, 2]}");
                Console.WriteLine($"Value [1, 2]: {matrixOfDoubles[1, 2]}");

                Console.WriteLine("Trying to get value on [-1, -1]:");
                Console.WriteLine(matrixOfDoubles[-1, -1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Init another matrix for testing Add extention.

            DiagonalMatrix<double> anotherMatrix = new(3);

            anotherMatrix[0, 0] = 1.2;
            anotherMatrix[1, 1] = -0.1;
            anotherMatrix[2, 2] = 0.0;

            Console.WriteLine($"\nMatrix #2: \n{anotherMatrix}");
            Console.WriteLine($"\nSum of matrices: \n" +
                $"{matrixOfDoubles.Add(anotherMatrix, (double x, double y) => x + y)}");

            //Testing of matrix ElementChanged event tracker.

            MatrixTracker<double> tracker = new(matrixOfDoubles);
            matrixOfDoubles[2, 2] = 30.0;
            matrixOfDoubles[1, 1] = 18;

            Console.WriteLine($"\nMatrix #1 after changing the element: \n{matrixOfDoubles}");
            Console.WriteLine(tracker.LastAction);

            try
            {
                tracker.Undo();
                Console.WriteLine($"Matrix #1 after Undo() method: \n{matrixOfDoubles}");

                tracker.Undo();
                Console.WriteLine($"Matrix #1 after Undo() method: \n{matrixOfDoubles}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
