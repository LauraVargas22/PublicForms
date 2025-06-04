using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class OptionQuestionsConfiguration : IEntityTypeConfiguration<OptionQuestions>
    {
        public void Configure(EntityTypeBuilder<OptionQuestions> builder)
        {
            builder.ToTable("option_questions");
            builder.HasKey(oq => oq.Id);
            builder.Property(oq => oq.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(oq => oq.CreatedAt).HasDefaultValue(DateTime.UtcNow);

            builder.Property(oq => oq.UpdatedAt).HasDefaultValue(DateTime.UtcNow);

            builder.Property(oq => oq.OptionId)
                .IsRequired()
                .HasColumnName("option_id");

            builder.Property(oq => oq.OptionCatalogId)
                .IsRequired()
                .HasColumnName("optioncatalog_id");

            builder.Property(oq => oq.OptionQuestionId)
                .IsRequired()
                .HasColumnName("optionquestion_id");

            builder.Property(oq => oq.CommentOptionres)
                .HasColumnName("comment_optionres");

            builder.Property(oq => oq.NumberOption)
                .HasColumnName("number_option")
                .HasMaxLength(20);
        }
    }
}