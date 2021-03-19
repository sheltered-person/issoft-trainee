using System;

namespace Task2
{
    //Sealed immutable type.

    public sealed record Segment
    {
        //Readonly segment properties.

        public int Left { get; }

        public int Right { get; }

        public uint Length => Right - Left;


        public Segment(int left, int right)
        {
            if (left > right)
            {
                Left = right;
                Right = left;
            }
            else
            {
                Left = left;
                Right = right;
            }
        }

        //Override ToString and GetHashCode (Equals overriden in records by default).

        public override string ToString()
        {
            return $"Segment [{Left}, {Right}]";
        }


        public override int GetHashCode()
        {
            return Left.GetHashCode() + Right.GetHashCode();
        }

        //Operators overloading.

        public static Segment operator +(Segment first, Segment second)
        {
            if (first is null || second is null)
            {
                throw new NullReferenceException("Error: " +
                    "sum operator can't work with the null.");
            }

            return new Segment(first.Left + second.Left, first.Right + second.Right);
        }


        public static explicit operator uint(Segment segment)
        {
            if (segment is null)
            {
                throw new NullReferenceException("Error: " +
                    "cast operator can't convert null.");
            }

            return (uint)segment.Length;
        }

        //This operator doesn't require null checking because ValueTuple is used.

        public static implicit operator Segment((int a, int b) tuple)
        {
            return new Segment(tuple.a, tuple.b);
        }
    }
}
