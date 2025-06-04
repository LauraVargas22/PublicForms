using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class OptionsResponseConfiguration : IEntityTypeConfiguration<OptionsResponse>
    {
        public void Configure(EntityTypeBuilder<OptionsResponse> builder)
        {
            builder.ToTable("options_responses");
            builder.HasKey(or => or.Id);
            builder.Property(or => or.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(or => or.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(or => or.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(or => or.OptionText)
                .HasColumnName("option_text");

            builder.HasMany(or => or.CategoryOptions)
               .WithOne(co => co.OptionsResponse)
               .HasForeignKey(co => co.OptionsResponseId);
               
            builder.HasMany(or => or.OptionQuestions)
               .WithOne(co => co.OptionsResponse)
               .HasForeignKey(co => co.OptionsResponseId);
        }
    }
}