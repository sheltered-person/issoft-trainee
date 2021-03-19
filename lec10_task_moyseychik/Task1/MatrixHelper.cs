using System;

namespace Task1
{
    public static class MatrixHelper
    {
        //Class with extension methods for DiagonalMatrix class.

        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> matrix1, 
            DiagonalMatrix<T> matrix2, Func<T, T, T> additionMethod)
        {
            if (matrix1 is null)
            {
                throw new NullReferenceException("Error: can't call instanse method" +
                    " for null-value object.");
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException("Error: method can't be " +
                    "called for null argument matrix.");
            }

            if (additionMethod is null)
            {
                throw new ArgumentNullException("Error: addition method can't be null.");
            }

            if (matrix1.Size < matrix2.Size)
            {
                DiagonalMatrix<T> temp = matrix1;
                matrix1 = matrix2;
                matrix2 = temp;
            }

            DiagonalMatrix<T> result = new(matrix1.Size);

            for (int i = 0; i < matrix2.Size; i++)
            {
                result[i, i] = additionMethod(matrix1[i, i], matrix2[i, i]);
            }

            for (int i = matrix2.Size; i < matrix1.Size; i++)
            {
                result[i, i] = matrix1[i, i];
            }

            return result;
        }
    }
}
