using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacanciesMS.Data.Entities;

namespace VacanciesMS.Data.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<OrganizationEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizationEntity> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(o => o.Name).HasMaxLength(100).IsRequired();

            builder.Property(o => o.Email).HasMaxLength(50).IsRequired();
        }
    }
}
