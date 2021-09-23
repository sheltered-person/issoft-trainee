using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Task2.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("Employees");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).IsUnicode().IsRequired().HasMaxLength(128);
            entity.Property(e => e.Lastname).IsUnicode().IsRequired().HasMaxLength(128);
            entity.Property(e => e.Email).IsUnicode().IsRequired().HasMaxLength(128);
        }
    }
}
