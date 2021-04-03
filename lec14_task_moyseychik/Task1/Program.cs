using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix matrix = new(4, 4);

            matrix[0, 0] = 5;
            matrix[1, 1] = 8;
            matrix[3, 1] = 5;

            Console.WriteLine(matrix);

            Console.WriteLine($"Zeros = {matrix.GetCount(0)}");
            Console.WriteLine($"Fives = {matrix.GetCount(5)}\n");

            matrix[1, 2] = 30;
            matrix[3, 1] = -10;
            matrix[1, 1] = 0;

            Console.WriteLine(matrix);

            Console.WriteLine($"\nZeros = {matrix.GetCount(0)}");
            Console.WriteLine($"Fives = {matrix.GetCount(5)}\n");

            foreach (int value in matrix)
            {
                Console.Write($"{value}\t");
            }

            foreach ((int i, int j, int value) in matrix.GetNonzeroElements())
            {
                Console.WriteLine($"matrix[{i}][{j}] = {value}");
            }
        }
    }
}
