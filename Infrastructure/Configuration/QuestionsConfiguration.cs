using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class QuestionsConfiguration : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.ToTable("questions");
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(q => q.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(q => q.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(q => q.QuestionNumber)
                .HasColumnName("question_number")
                .HasMaxLength(10);

            builder.Property(q => q.ResponseType)
                .HasColumnName("response_type")
                .HasMaxLength(10);

            builder.Property(q => q.CommentQuestion)
                .HasColumnName("comment_question");

            builder.Property(q => q.QuestionText)
                .HasColumnName("question_text")
                .IsRequired();

            builder.HasMany(q => q.OptionQuestions)
               .WithOne(oq => oq.Questions)
               .HasForeignKey(oq => oq.QuestionId);

            builder.HasMany(q => q.SubQuestions)
               .WithOne(sq => sq.Questions)
               .HasForeignKey(sq => sq.QuestionId);

            builder.HasMany(q => q.SumaryOptions)
               .WithOne(so => so.Questions)
               .HasForeignKey(so => so.QuestionId);
        }
    }
}