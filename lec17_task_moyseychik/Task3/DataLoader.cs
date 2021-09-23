using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Task3
{
    //Static functions for loading and grouping data from file.
    public static class DataLoader
    {
        //Load data from file, split lines by delimiter.
        public static List<(string, Vacation)> LoadDataFromFile(
            string file, char delimiter)
        {
            using StreamReader reader = new StreamReader(file);

            List<(string, Vacation)> data = new();
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    data.Add(ParseLine(line, delimiter));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return data;
        }

        //Filter by bounds and group tuples of data to EmployeeVacations objects using PLINQ.
        public static List<EmployeeVacations> GroupData(
            List<(string name, Vacation vacation)> data, 
            DateTime lowerBound, DateTime upperBound)
        {
            return data
                .AsParallel()
                .Where(x => x.vacation.Start >= lowerBound 
                    && x.vacation.End <= upperBound)
                .GroupBy(x => x.name)
                .Select(group => new EmployeeVacations(group.Key, group
                    .Select(x => x.vacation)
                    .ToList()))
                .ToList();
        }

        //File line parser, split line by delimiter.
        private static (string, Vacation) ParseLine(string line, 
            char delimiter)
        {
            string[] parts = line.Split(delimiter);

            if (parts.Length != 3)
            {
                throw new ArgumentException($"Line has invalid format, " +
                    $"use string{delimiter}DateTime{delimiter}DateTime instead.");
            }

            return (parts[0], new(parts[1], parts[2]));
        }
    }
}
