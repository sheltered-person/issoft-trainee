using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Task2
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            using ApplicationContext context = new();

            foreach (Employee employee in context.Employees
                .Include(x => x.Vacations)
                .Where(x => x.Vacations
                    .Any(v => EF.Functions.DateDiffDay(v.Begin, v.End) >= 30))
                .ToList())
            {
                Console.WriteLine($"[{employee.Id}] {employee.Name} {employee.Lastname}");
                Console.WriteLine("Vacations:");

                foreach (Vacation vacation in employee.Vacations)
                {
                    Console.WriteLine($"\t{vacation.Begin:d} - {vacation.End:d}");
                }

                Console.WriteLine("-----------------------------------------------------");
            }

            Console.WriteLine();

            foreach (Training training in context.Trainings.ToList())
            {
                Console.WriteLine($"[{training.Id}] {training.Name} ({training.Begin:d} - {training.End:d})");

                training.Employees = context.Employees
                    .Where(e => !e.Vacations
                        .Any(v => (v.Begin < training.End && v.End > training.Begin)))
                    .ToList();

                Console.WriteLine("Participants:");

                foreach (Employee employee in training.Employees)
                {
                    Console.WriteLine($"\t[{employee.Id}] {employee.Name} {employee.Lastname}");
                }

                Console.WriteLine("------------------------------------------------------");
            }

            context.SaveChanges();
        }
    }
}
