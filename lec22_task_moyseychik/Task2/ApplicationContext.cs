using Microsoft.EntityFrameworkCore;
using Model;
using Task2.Config;

namespace Task2
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connection = "Data Source=(localdb)\\ProjectsV13;" +
                                              "Initial Catalog=Db;";

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Vacation> Vacations { get; set; }

        public DbSet<Training> Trainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new TrainingConfig());
            modelBuilder.ApplyConfiguration(new VacationConfig());
        }
    }
}
