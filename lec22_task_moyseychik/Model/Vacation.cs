using System;

namespace Model
{
    public class Vacation : Entity<Guid>
    {
        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int Length => (End - Begin).Days;

        public Vacation() { }

        public Vacation(DateTime begin, DateTime end, Guid employeeId)
        {
            Id = Guid.NewGuid();

            Begin = begin;
            End = end;
            EmployeeId = employeeId;
        }
    }
}
