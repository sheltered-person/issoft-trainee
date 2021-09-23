using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            List<(string, Vacation)> data;
            List<EmployeeVacations> grouppedData;

            try
            {
                data = DataLoader.LoadDataFromFile("data.csv", ',');
                grouppedData = DataLoader
                    .GroupData(data, DateTime.Parse("7/1/2016"),
                    DateTime.Parse("12/31/2016"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            foreach (EmployeeVacations vacations in grouppedData)
            {
                Console.WriteLine(vacations);
            }

            try
            {
                DataSerializer.SerializeToFile(grouppedData, "persons.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
