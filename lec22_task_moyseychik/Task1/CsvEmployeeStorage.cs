using System;
using System.Collections.Generic;
using System.IO;
using Model;

namespace Task1
{
    public class CsvEmployeeStorage : IEmployeeStorage
    {
        private readonly string _filename;

        private readonly char _delimiter = ',';

        private readonly Dictionary<string, Employee> _employees;

        private readonly List<Vacation> _vacations;

        public List<Employee> Employees => new(_employees.Values);

        public List<Vacation> Vacations => new(_vacations);

        public CsvEmployeeStorage(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("Can't work with storage" +
                                            " with null or empty name, please " +
                                            "set correct filename.");
            }

            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"Can't find file {filename}," +
                                                $" please specify correct filename or path.");
            }

            _filename = filename;

            _employees = new();
            _vacations = new();
        }

        public void LoadData()
        {
            using StreamReader reader = new(_filename);

            string line;

            while ((line = reader.ReadLine()) is not null)
            {
                try
                {
                    ParseFileLine(line, out Employee employee, out Vacation vacation);

                    if (!_employees.TryAdd(employee.Email, employee))
                    {
                        vacation.EmployeeId = _employees[employee.Email].Id;
                    }

                    _vacations.Add(vacation);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("An attempt to add" +
                                                " employee with exiting Id occurred.");
                }
                catch (Exception)
                {
                    throw new FormatException($"File line has " +
                                              $"incorrect format: {line}");
                }
            }
        }

        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void AddVacation(Vacation vacation)
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

        public void ClearStorage()
        {
            throw new NotImplementedException();
        }

        private void ParseFileLine(string line, out Employee employee, 
            out Vacation vacation)
        {
            string[] parts = line.Split(_delimiter);
            string[] employeeData = parts[0].Split(' ');

            employee = new(employeeData[0],
                employeeData[1]);

            vacation = new(DateTime.Parse(parts[1]),
                DateTime.Parse(parts[2]),
                employee.Id);
        }
    }
}
