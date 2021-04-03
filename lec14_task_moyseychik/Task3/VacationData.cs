using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    //Specifies enumarable table of employee vacations for one year.
    public class VacationData : IEnumerable<Vacation>
    {
        public int Year { get; init; }

        private List<Vacation> data;

        public VacationData(int year) 
        {
            if (year <= 0)
            {
                throw new ArgumentException($"Invalid year value. Year: {year}");
            }

            Year = year;
            data = new();
        }

        //Addition method for IEnumerable standard initialization + data validation.
        public void Add(Vacation vacation)
        {
            if (vacation.Start.Year != Year || vacation.End.Year != Year)
            {
                throw new ArgumentException($"The current instanse of VacationData" +
                    $" should hold info for {Year}.");
            }

            if (HasIntersection(vacation))
            {
                throw new ArgumentException($"Vacation periods of one person" +
                    $" can't intersect. Employee: {vacation.EmployeeName}");
            }

            data.Add(vacation);
        }

        //IEnumerable methods.
        public IEnumerator<Vacation> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Task 3.2 method.
        public TimeSpan Average()
        {
            return TimeSpan.FromMilliseconds(data
                .Average(Vacation.MillisecondsLength));
        }

        //Task 3.3 method.
        public IEnumerable<(string, TimeSpan)> AverageByEmployee()
        {
            return from vacation in data
                   group vacation by vacation.EmployeeName into vacations
                   select (name: vacations.Key, 
                   time: TimeSpan.FromMilliseconds(vacations
                   .Average(Vacation.MillisecondsLength)));
        }

        //Task 3.4 method.
        public IEnumerable<(int, int)> EmployeesByMonth()
        {
            return from month in Enumerable.Range(1, 12)
                   select (month, (from vacation in data
                                   where vacation.Start.Month <= month && month <= vacation.End.Month
                                   group vacation by vacation.EmployeeName).Count());
        }

        //Task 3.5 method.
        public IEnumerable<DateTime> AvailableYearDays()
        {
            DateTime start = new(Year, 1, 1);
            int daysNumber = DateTime.IsLeapYear(Year) ? 365 : 364;

            return (from days in Enumerable.Range(1, daysNumber)
                   select start.AddDays(days))
                   .Except(from vacation in data
                           select vacation.Start);
        }

        //ToString override for convenient table representation.
        public override string ToString()
        {
            StringBuilder vacations = new("Employee\tStart            \tEnd\n" +
                "----------------------------------------------------------\n");

            foreach (Vacation vacation in data)
            {
                vacations.Append($"{vacation.EmployeeName}\t" +
                    $"{vacation.Start}\t" +
                    $"{vacation.End}\n");
            }

            return vacations.ToString();
        }

        //Task 3.6. Check, if new data intersects with the old one.
        private bool HasIntersection(Vacation x)
        {
            return (from vacation in data
                    where x.EmployeeName == vacation.EmployeeName
                    select vacation).Any(vacation => vacation.IntersectsWith(x));
        }
    }
}
