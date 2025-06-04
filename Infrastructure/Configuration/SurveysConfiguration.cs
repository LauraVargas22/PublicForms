using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SurveysConfiguration : IEntityTypeConfiguration<Surveys>
    {
        public void Configure(EntityTypeBuilder<Surveys> builder)
        {
            builder.ToTable("surveys");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(s => s.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(s => s.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(s => s.ComponentHtml)
                .HasColumnName("componenthtml")
                .HasMaxLength(20);

            builder.Property(s => s.ComponentReact)
                .HasColumnName("componentreact")
                .HasMaxLength(20);

            builder.Property(s => s.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(s => s.Instruction)
                .HasColumnName("instruction");

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.HasMany(s => s.SumaryOptions)
               .WithOne(so => so.Surveys)
               .HasForeignKey(so => so.SurveyId);
               
            builder.HasMany(s => s.Chapters)
               .WithOne(c => c.Surveys)
               .HasForeignKey(c => c.SurveyId);
        }
    }
}