using System;
using System.Collections.Generic;

namespace Model
{
    public class Employee : Entity<Guid>
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public ICollection<Vacation> Vacations { get; set; }

        public ICollection<Training> Trainings { get; set; }

        public Employee() { }

        public Employee(string name, string lastname)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Employee name is required, " +
                                            "please set not null or empty string.");
            }

            if (string.IsNullOrEmpty(lastname))
            {
                throw new ArgumentException("Employee lastname is required, " +
                                            "please set not null or empty string.");
            }

            Name = name;
            Lastname = lastname;

            Id = Guid.NewGuid();
            Email = $"{Name.ToLower()}{Lastname.ToLower()}@issoft.by";
        }
    }
}
