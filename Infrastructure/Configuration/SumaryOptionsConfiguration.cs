using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SumaryOptionsConfiguration : IEntityTypeConfiguration<SumaryOptions>
    {
        public void Configure(EntityTypeBuilder<SumaryOptions> builder)
        {
            builder.ToTable("sumary_options");
            builder.HasKey(so => so.Id);
            builder.Property(so => so.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(so => so.CodeNumber)
                .HasColumnName("code_number")
                .HasMaxLength(20);

            builder.Property(so => so.Valuerta)
                .HasColumnName("valuerta");
        }
    }
}