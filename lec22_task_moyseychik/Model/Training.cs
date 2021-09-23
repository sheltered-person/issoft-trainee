using System;
using System.Collections.Generic;

namespace Model
{
    public class Training : Entity<Guid>
    {
        public string Name { get; set; }

        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
