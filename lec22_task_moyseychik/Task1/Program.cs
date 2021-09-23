using System;
using Microsoft.Data.SqlClient;
using Model;

namespace Task1
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            CsvEmployeeStorage csvStorage;

            try
            {
                csvStorage = new("data.csv");
                csvStorage.LoadData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            SqlConnectionStringBuilder connectionString = new()
            {
                DataSource = "(localdb)\\ProjectsV13",
                InitialCatalog = "Db"
            };

            DbEmployeeStorage dbStorage;

            try
            {
                dbStorage = new(connectionString.ConnectionString);
                dbStorage.ClearStorage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (Employee employee in csvStorage.Employees)
            {
                dbStorage.AddEmployee(employee);
            }

            foreach (Vacation vacation in csvStorage.Vacations)
            {
                dbStorage.AddVacation(vacation);
            }

            try
            {
                dbStorage.SaveData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
