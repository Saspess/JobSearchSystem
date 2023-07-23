using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacanciesMS.Data.Entities;

namespace VacanciesMS.Data.Configurations
{
    public class VacancyConfiguration : IEntityTypeConfiguration<VacancyEntity>
    {
        public void Configure(EntityTypeBuilder<VacancyEntity> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(v => v.Name).HasMaxLength(255).IsRequired();

            builder.Property(v => v.Description).HasMaxLength(255).IsRequired();
        }
    }
}
