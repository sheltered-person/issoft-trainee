using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Task2.Config
{
    public class VacationConfig : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> entity)
        {
            entity.ToTable("Vacations");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Begin).IsRequired().HasColumnType("date");
            entity.Property(e => e.End).IsRequired().HasColumnType("date");
            entity.Ignore(e => e.Length);

            entity.HasOne(e => e.Employee)
                .WithMany(e => e.Vacations)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
