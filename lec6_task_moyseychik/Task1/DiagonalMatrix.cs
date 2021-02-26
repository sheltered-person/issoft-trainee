using System;
using System.Text;

namespace Task1
{
    public class DiagonalMatrix
    {
        //Matrix elements.
        private int[] elements;

        //Readonly size property.
        public int Size 
        { 
            get => elements?.Length ?? 0;
        }

        public DiagonalMatrix(params int[] matrix)
        {
            Array.Copy(matrix, elements, matrix.Length);
        }

        //Matrix indexer.
        public int this[int i, int j]
        {
            get
            {
                if (i != j || i < 0 || i >= Size)
                {
                    return 0;
                }

                return elements[i];
            }

            set
            {
                if (i == j && i >= 0 && i < Size)
                {
                    elements[i] = value;
                }
            }
        }

        //Track method produces sum of matrix elements.
        public long Track()
        {
            long sum = 0;

            foreach (int element in elements)
            {
                sum += element;
            }

            return sum;
        }

        //Check for the equality.
        public override bool Equals(object obj)
        {
            if (obj is DiagonalMatrix diag && Size == diag.Size)
            {
                for (int i = 0; i < Size; i++)
                {
                    if (elements[i] != diag[i, i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        //Override hash in pair with Equals.
        public override int GetHashCode()
        {
            int hash = 0;

            foreach (int element in elements)
            {
                hash += element.GetHashCode();
            }

            return hash;
        }

        //Return string representation of matrix.
        /*  The usage of StringBuilder decreases the time and memory complexity.
            We can use concatenation of immutable strings here (according to our lections), 
            but I see no reasons for it.*/

        public override string ToString()
        {
            if (Size == 0)
            {
                return "0";
            }

            StringBuilder matrix = new StringBuilder();

            for (int i = 0; i < Size; i++) 
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                    {
                        matrix.Append($"{elements[i]}\t");
                    }
                    else 
                    {
                        matrix.Append("0\t");
                    }
                }

                matrix.Append('\n');
            }

            return matrix.ToString();
        }
    }
}
