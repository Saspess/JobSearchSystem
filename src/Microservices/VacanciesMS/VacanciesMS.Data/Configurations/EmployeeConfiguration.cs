using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacanciesMS.Data.Entities;

namespace VacanciesMS.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();

            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();

            builder.Property(e => e.Email).HasMaxLength(50).IsRequired();
        }
    }
}
