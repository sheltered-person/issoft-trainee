using System;

namespace Task3
{
    public class Vacation
    {
        public string EmployeeName { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public Vacation(string employeeName, DateTime start, DateTime end)
        {
            if (string.IsNullOrEmpty(employeeName))
            {
                throw new ArgumentException("Employee name should be defined.");
            }

            EmployeeName = employeeName;

            if (start > end)
            {
                Start = end;
                End = start;
            }
            else
            {
                Start = start;
                End = end;
            }
        }

        //Additional ctor for convenient testing.
        public Vacation(string employeeName, string start, string end) 
            : this(employeeName, DateTime.Parse(start), DateTime.Parse(end)) { }

        //Vacation length in milliseconds for average counting.
        public static double MillisecondsLength(Vacation x) 
            => (x.End - x.Start).TotalMilliseconds;

        //Method for check intersection of vacation periods.
        public bool IntersectsWith(Vacation x)
            => !(Start > x.End || End < x.Start);
    }
}
