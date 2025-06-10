using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MemberRolsConfiguration : IEntityTypeConfiguration<MemberRols>
    {
        public void Configure(EntityTypeBuilder<MemberRols> builder)
        {
            builder.ToTable("MemberRols");
            builder.HasKey(e => new { e.MemberId, e.RolId });

            builder.HasOne(e => e.Member)
                .WithMany(e => e.MemberRols)
                .HasForeignKey(e => e.MemberId);

            builder.HasOne(e => e.Rol)
                .WithMany(e => e.MemberRols)
                .HasForeignKey(e => e.RolId);
        }
    }
}