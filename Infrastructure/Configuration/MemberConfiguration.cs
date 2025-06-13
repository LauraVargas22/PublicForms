using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserMemberConfiguration : IEntityTypeConfiguration<UserMember>
    {
        public void Configure(EntityTypeBuilder<UserMember> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("members");
            builder.HasKey(e => e.Id);

            builder.Property(p => p.Id)
                    .IsRequired();

            builder.Property(p => p.Username)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.HasMany(p => p.RefreshTokens)
                    .WithOne(p => p.UserMembers)
                    .HasForeignKey(p => p.UserMemberId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}