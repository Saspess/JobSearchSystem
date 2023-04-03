using IdentityMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityMS.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(u => u.Password).HasMaxLength(200).IsRequired();

            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();

            builder.Property(u => u.Role).HasMaxLength(50).IsRequired();
        }
    }
}
