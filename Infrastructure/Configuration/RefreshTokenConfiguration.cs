using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("refresh_tokens");
            builder.HasKey(e => e.Id); // Asumiendo que 'Id' es la clave primaria

            builder.Property(e => e.UserMemberId)
                .IsRequired();

            builder.HasOne(e => e.UserMembers)
                .WithMany(m => m.RefreshTokens)
                .HasForeignKey(e => e.UserMemberId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}