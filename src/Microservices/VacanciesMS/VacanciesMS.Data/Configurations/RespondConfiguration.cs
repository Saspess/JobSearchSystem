using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VacanciesMS.Data.Entities;

namespace VacanciesMS.Data.Configurations
{
    public class RespondConfiguration : IEntityTypeConfiguration<RespondEntity>
    {
        public void Configure(EntityTypeBuilder<RespondEntity> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(r => r.VacancyId).IsRequired();

            builder.Property(r => r.EmployeeId).IsRequired();
        }
    }
}
