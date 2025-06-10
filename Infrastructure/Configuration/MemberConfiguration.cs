using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("members");
            builder.HasKey(m => m.Id); // Asumiendo que 'Id' es la clave primaria

            builder.Property(m => m.Username)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.Property(m => m.Email)
                    .IsRequired()
                    .HasMaxLength(200);
        }
    }
}