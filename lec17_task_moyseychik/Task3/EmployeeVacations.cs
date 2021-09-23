using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    //Incapsulates employee name and his vacations list.
    public class EmployeeVacations
    {
        public string Name { get; }

        //Returns copy to avoid changes in private field.
        public IEnumerable<Vacation> Vacations => _vacations.ToArray();

        private List<Vacation> _vacations;

        //Instantiate object with mentioned name (not null or empty) and vacations.
        //Vacations list is checked for the intersections.
        public EmployeeVacations(string name, List<Vacation> vacations)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Employee name can't be null or empty.");
            }

            if (vacations is null)
            {
                throw new ArgumentNullException("Storage of employees without " +
                    "vacations is prohibited.");
            }

            if (HasIntersections(vacations))
            {
                throw new ArgumentException("One employee can't have more " +
                    "than 1 vacation at a time.");
            }

            Name = name;
            _vacations = new(vacations);
        }

        //String representation of employee name and his list of vacations for testing.
        public override string ToString()
        {
            StringBuilder data = new($"Employee: {Name}\n" +
                $"Vacations:\n");

            foreach (Vacation vacation in _vacations)
            {
                data.Append($"\t{vacation}\n");
            }

            return data.ToString();
        }

        //Checks vacation list for intersections with PLINQ methods.
        private bool HasIntersections(List<Vacation> vacations)
        {
            return vacations
                .AsParallel()
                .Any(v => vacations
                    .Except(new List<Vacation>() { v })
                    .Any(x => x.IntersectsWith(v)));
        }
    }
}
