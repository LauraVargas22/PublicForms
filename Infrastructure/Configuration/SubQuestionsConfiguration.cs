using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SubQuestionsConfiguration : IEntityTypeConfiguration<SubQuestions>
    {
        public void Configure(EntityTypeBuilder<SubQuestions> builder)
        {
            builder.ToTable("sub_questions");
            builder.HasKey(sq => sq.Id);
            builder.Property(sq => sq.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(sq => sq.CreatedAt).HasDefaultValue(DateTime.UtcNow);

            builder.Property(sq => sq.UpdatedAt).HasDefaultValue(DateTime.UtcNow);

            builder.Property(sq => sq.SubquestionNumber)
                .HasColumnName("subquestion_number")
                .HasMaxLength(10);

            builder.Property(sq => sq.CommentSubQuestion)
                .HasColumnName("comment_subquestion");

            builder.Property(sq => sq.SubquestionText)
                .HasColumnName("subquestion_text")
                .IsRequired();

            builder.HasMany(sq => sq.OptionQuestions)
               .WithOne(oq => oq.SubQuestions)
               .HasForeignKey(oq => oq.SubquestionId);
        }
    }
}