using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Model;

namespace Task1
{
    public class DbEmployeeStorage : IEmployeeStorage
    {
        private readonly string _connectionString;

        private List<Employee> _employees;

        private List<Vacation> _vacations;

        public List<Employee> Employees => new(_employees);

        public List<Vacation> Vacations => new(_vacations);

        public DbEmployeeStorage(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString),
                    "Parameter can't be null to open connection with storage.");
            }

            _connectionString = connectionString;
        }

        public void LoadData()
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public void AddVacation(Vacation vacation)
        {
            _vacations.Add(vacation);
        }

        public void SaveData()
        {
            using SqlConnection connection = new(_connectionString);

            connection.Open();

            SaveEmployees(connection);
            SaveVacations(connection);
        }

        public void ClearStorage()
        {
            _employees = new();
            _vacations = new();

            using SqlConnection connection = new(_connectionString);

            string[] commands =
            {
                "DELETE FROM Employees;",
                "DELETE FROM Vacations;"
            };

            connection.Open();

            foreach (string commandText in commands)
            {
                SqlCommand command = new(commandText, connection);
                command.ExecuteNonQuery();
            }
        }

        private void SaveEmployees(SqlConnection connection)
        {
            SqlCommand command = new("INSERT INTO Employees " +
                                     "VALUES (@id, @email, @name, @lastname);", 
                                     connection);

            command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
            command.Parameters.Add("@email", SqlDbType.NVarChar);
            command.Parameters.Add("@name", SqlDbType.NVarChar);
            command.Parameters.Add("@lastname", SqlDbType.NVarChar);

            foreach (Employee employee in _employees)
            {
                command.Parameters["@id"].Value = employee.Id;
                command.Parameters["@email"].Value = employee.Email;
                command.Parameters["@name"].Value = employee.Name;
                command.Parameters["@lastname"].Value = employee.Lastname;

                command.ExecuteNonQuery();
            }
        }

        private void SaveVacations(SqlConnection connection)
        {
            SqlCommand command = new("INSERT INTO Vacations  " +
                                     "VALUES (@id, @begin, @end, @employeeId);", 
                                     connection);

            command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
            command.Parameters.Add("@begin", SqlDbType.Date);
            command.Parameters.Add("@end", SqlDbType.Date);
            command.Parameters.Add("@employeeId", SqlDbType.UniqueIdentifier);

            foreach (Vacation vacation in _vacations)
            {
                command.Parameters["@id"].Value = vacation.Id;
                command.Parameters["@begin"].Value = vacation.Begin;
                command.Parameters["@end"].Value = vacation.End;
                command.Parameters["@employeeId"].Value = vacation.EmployeeId;

                command.ExecuteNonQuery();
            }
        }
    }
}
