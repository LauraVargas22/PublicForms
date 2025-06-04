using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ChaptersConfiguration : IEntityTypeConfiguration<Chapters>
    {
        public void Configure(EntityTypeBuilder<Chapters> builder)
        {
            builder.ToTable("chapters");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.ComponentHtml)
                .HasColumnName("componenthtml")
                .HasMaxLength(20);

            builder.Property(c => c.ComponentReact)
                .HasColumnName("componentreact")
                .HasMaxLength(20);

            builder.Property(c => c.ChapterNumber)
                .HasColumnName("chapter_number")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.ChapterTitle)
                .HasColumnName("chapter_title")
                .IsRequired();

            builder.HasMany(c => c.Questions)
               .WithOne(q => q.Chapters)
               .HasForeignKey(q => q.ChapterId);
        }
    }
}