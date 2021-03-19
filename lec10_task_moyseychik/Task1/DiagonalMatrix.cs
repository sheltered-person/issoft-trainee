using System;
using System.Text;

namespace Task1
{
    public class DiagonalMatrix<T>
    {
        //Matrix elements.
        private readonly T[] elements;

        //Readonly size property.
        public int Size => elements.Length;

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        public DiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentNullException("Error: size was negative number.");
            }

            elements = new T[size];
        }

        //Matrix indexer.
        public T this[int i, int j]
        {
            get
            {
                if (CheckIndexes(i, j))
                {
                    return elements[i];
                }

                return default;
            }

            set
            {
                if (CheckIndexes(i, j) && value != null && !Equals(elements[i], value)) 
                {
                    T old = elements[i];
                    elements[i] = value;

                    OnElementChanged(new ElementChangedEventArgs<T>(i,
                            old, value));
                }
            }
        }

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }

        //Old track method, modified for new task.
        public T Track(Func<T, T, T> additionMethod)
        {
            T sum = default;

            foreach (T element in elements)
            {
                sum = additionMethod(sum, element);
            }

            return sum;
        }

        //Check for the equality.
        public override bool Equals(object obj)
        {
            if (obj is DiagonalMatrix<T> diag && Size == diag.Size)
            {
                for (int i = 0; i < Size; i++)
                {
                    if (elements[i].Equals(diag[i, i]))
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

            foreach (T element in elements)
            {
                hash += element.GetHashCode();
            }

            return hash;
        }

        //Return string representation of matrix.
        public override string ToString()
        {
            if (Size == 0)
            {
                return "Empty";
            }

            StringBuilder matrix = new();

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

        private bool CheckIndexes(int i, int j)
        {
            if (i < 0 || j < 0 || i >= Size || j >= Size)
            {
                throw new IndexOutOfRangeException(
                        $"Error: index is out of the matrix.");
            }

            return i == j;
        }
    }
}
