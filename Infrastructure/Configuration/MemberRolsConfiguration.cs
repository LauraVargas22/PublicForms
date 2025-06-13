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
            builder.HasKey(e => new { e.UserMemberId, e.RolId });

            builder.HasOne(e => e.UserMembers)
                .WithMany(e => e.MemberRols)
                .HasForeignKey(e => e.UserMemberId);

            builder.HasOne(e => e.Rol)
                .WithMany(e => e.MemberRols)
                .HasForeignKey(e => e.RolId);
        }
    }
}