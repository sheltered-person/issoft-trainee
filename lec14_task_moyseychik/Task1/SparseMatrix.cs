using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    /*For the storage of sparse matrix List Of Lists concept was used
      due to the good average performance of constructing the matrix
      and accessing the elements (sorted list provides O(log n) search and insert).*/
    public class SparseMatrix : IEnumerable<int>
    {
        public int Rows { get; init; }
        public int Columns { get; init; }

        private SortedList<int, int>[] values;

        public SparseMatrix(int rows, int columns)
        {
            if (rows <= 0)
            {
                throw new ArgumentException("Rows number in matrix can't be 0 or less.");
            }

            if (columns <= 0)
            {
                throw new ArgumentException("Columns number in matrix can't be 0 or less.");
            }

            Rows = rows;
            Columns = columns;

            values = new SortedList<int, int>[Rows];

            for (int i = 0; i < Rows; i++)
            {
                values[i] = new();
            }
        }

        //Matrix indexer.
        public int this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);

                foreach ((int key, int value) in values[i])
                {
                    if (key == j)
                    {
                        return value;
                    }
                }

                return 0;
            }

            set
            {
                CheckIndexes(i, j);

                if (value == 0)
                {
                    if (values[i].Count != 0)
                    {
                        values[i].Remove(j);
                    }
                }
                else
                {
                    if (values[i].Count == 0)
                    {
                        values[i].Add(j, value);
                    }
                    else
                    {
                        if (values[i].ContainsKey(j))
                        {
                            values[i][j] = value;
                        }
                        else
                        {
                            values[i].Add(j, value);
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder matrix = new();

            int i = 0;

            foreach (int value in this)
            {
                matrix.Append($"{value}\t");
                i++;

                if (i >= Columns)
                {
                    matrix.Append('\n');
                    i = 0;
                }
            }

            return matrix.ToString();
        }

        //IEnumerable interface methods, enumerate all matrix elements.
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                var enumerator = values[i].GetEnumerator();

                if (!enumerator.MoveNext())
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        yield return 0;
                    }
                }
                else
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        int value = 0;

                        if (enumerator.Current.Key == j)
                        {
                            value = enumerator.Current.Value;
                            enumerator.MoveNext();
                        }

                        yield return value;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Enumerate non-zero elements.
        public IEnumerable<(int, int, int)> GetNonzeroElements()
        {
            for (int i = 0; i < Rows; i++)
            {
                foreach ((int j, int value) in values[i])
                {
                    yield return (i, j, value);
                }
            }
        }

        //Count the specified element repeatings in matrix.
        public int GetCount(int x)
        {
            int counter = 0;

            if (x == 0)
            {
                counter = Rows * Columns;

                foreach (var row in values)
                {
                    counter -= row.Count;
                }
            }
            else
            {
                foreach (SortedList<int, int> row in values)
                {
                    foreach (int value in row.Values)
                    {
                        if (value == x)
                        {
                            counter++;
                        }
                    }
                }
            }

            return counter;
        }

        //Check if the index is out of the bounds.
        private void CheckIndexes(int i, int j)
        {
            if (i < 0 || i >= Rows || j < 0 || j >= Rows)
            {
                throw new IndexOutOfRangeException($"Matrix{Rows}x{Columns} index is out of range.");
            }
        }
    }
}
