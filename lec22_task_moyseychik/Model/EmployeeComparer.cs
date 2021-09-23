using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Model
{
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (x is null && y is null)
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            return x.Id.Equals(y.Id);
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return (obj as Employee).Id.GetHashCode();
        }
    }
}
