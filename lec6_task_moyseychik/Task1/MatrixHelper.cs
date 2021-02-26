using System;

namespace Task1
{
    public static class MatrixHelper
    {
        //Class with extension methods for DiagonalMatrix class.

        public static DiagonalMatrix Add(this DiagonalMatrix matrix1, 
            DiagonalMatrix matrix2)
        {
            if (matrix1 is null || matrix2 is null)
            {
                return new DiagonalMatrix();
            }

            if (matrix1.Size < matrix2.Size)
            {
                DiagonalMatrix temp = matrix1;
                matrix1 = matrix2;
                matrix2 = temp;
            }

            int[] elements = new int[matrix1.Size];

            for (int i = 0; i < matrix2.Size; i++)
            {
                elements[i] = matrix1[i, i] + matrix2[i, i];
            }

            for (int i = matrix2.Size; i < matrix1.Size; i++)
            {
                elements[i] = matrix1[i, i];
            }

            return new DiagonalMatrix(elements);
        }
    }
}
