using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VacationData data;

            try
            {
                data = new VacationData(2020) 
                {
                    new("Ivanov Ivan", "01/01/2020", "07/01/2020"),
                    new("Petrov Petr", "15/01/2020", "20/03/2020"),
                    new("Ivanov Ivan", "10/01/2020", "21/01/2020"),
                    new("Sidorov Sid", "12/03/2020", "04/04/2020")
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine(data);
            Console.WriteLine($"Average vacation length: {data.Average().TotalDays} days\n");
            Console.WriteLine("Average vacation length by employees:\n");

            foreach ((string name, TimeSpan time) in data.AverageByEmployee())
            {
                Console.WriteLine($"\t{name} : {time.TotalDays} days");
            }

            Console.WriteLine("\nNumber of employees on vacation by month:\n");

            foreach ((int month, int count) in data.EmployeesByMonth())
            {
                Console.WriteLine($"\tMonth {month}: {count} people on vacation");
            }

            Console.WriteLine("\nAvailable year days where employees don't start any vacation:\n");

            foreach (DateTime day in data.AvailableYearDays())
            {
                Console.WriteLine($"\t{day.ToString("d")}");
            }

            Console.WriteLine("\nTry to add data that intersects with previous info:");

            try
            {
                data.Add(new Vacation("Sidorov Sid", "02/04/2020", "20/04/2020"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
