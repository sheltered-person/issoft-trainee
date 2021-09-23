using System;

namespace Task2
{
    //Structure represents an Euclidean squared distance between points.
    public struct Distance
    {
        //Position of y point in the train data.
        public int Index { get; }

        //Distance.
        public double SquaredDistance { get; }

        //Takes two points and y index and counts distance.
        public Distance(int index, (double x, double y) a, (double x, double y) b)
        {
            Index = index;
            SquaredDistance = Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2);
        }
    }
}
