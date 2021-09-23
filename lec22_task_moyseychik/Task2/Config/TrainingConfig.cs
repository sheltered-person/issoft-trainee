using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Task2.Config
{
    public class TrainingConfig : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> entity)
        {
            entity.ToTable("Trainings");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).IsRequired().IsUnicode().HasMaxLength(64);
            entity.Property(e => e.Begin).IsRequired().HasColumnType("date");
            entity.Property(e => e.End).IsRequired().HasColumnType("date");
            entity.Property(e => e.Description).IsRequired(false).IsUnicode();

            entity.HasMany(e => e.Employees)
                .WithMany(e => e.Trainings)
                .UsingEntity<EmployeeTraining>(
                    right => right.HasOne<Employee>().WithMany()
                        .HasForeignKey(e => e.EmployeeId)
                        .OnDelete(DeleteBehavior.Cascade),
                    left => left.HasOne<Training>().WithMany()
                        .HasForeignKey(e => e.TrainingId)
                        .OnDelete(DeleteBehavior.Cascade),
                    join => join.ToTable("EmployeeTrainings"));
        }
    }
}
