using System;

namespace Task3
{
    //Time period struct.
    public struct Vacation
    {
        public DateTime Start { get; }

        public DateTime End { get; }

        //Constructor with check for dates sequence.
        public Vacation(DateTime start, DateTime end)
        {
            if (start > end)
            {
                DateTime temp = start;
                start = end;
                end = temp;
            }

            Start = start;
            End = end;
        }

        //Constructor with DateTime parser to simplify calling from the code.
        public Vacation(string start, string end) 
            : this(DateTime.Parse(start), DateTime.Parse(end)) { }

        //Checks if to time periods intersects or not.
        public bool IntersectsWith(Vacation vacation)
            => !(Start > vacation.End || End < vacation.Start);

        //String vacation period representation.
        public override string ToString() 
            => $"{Start.ToString("d")} - {End.ToString("d")}";
    }
}
