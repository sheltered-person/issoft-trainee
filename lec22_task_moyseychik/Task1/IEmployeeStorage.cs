using System.Collections.Generic;
using Model;

namespace Task1
{
    public interface IEmployeeStorage
    {
        public List<Employee> Employees { get; }

        public List<Vacation> Vacations { get; }

        public void LoadData();

        public void AddEmployee(Employee employee);

        public void AddVacation(Vacation vacation);

        public void SaveData();

        public void ClearStorage();
    }
}
