using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CategoriesCatalogConfiguration : IEntityTypeConfiguration<CategoriesCatalog>
    {
        public void Configure(EntityTypeBuilder<CategoriesCatalog> builder)
        {
            builder.ToTable("categories_catalogs");
            builder.HasKey(cc => cc.Id);
            builder.Property(cc => cc.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(cc => cc.CreatedAt).HasDefaultValue(DateTime.UtcNow);

            builder.Property(cc => cc.UpdatedAt).HasDefaultValue(DateTime.UtcNow);

            builder.Property(cc => cc.Name)
                .HasColumnName("name")
                .HasMaxLength(255);

            builder.HasMany(cc => cc.CategoryOptions)
               .WithOne(co => co.CategoriesCatalog)
               .HasForeignKey(co => co.CategoriesOptionsId);

            builder.HasMany(cc => cc.OptionQuestions)
               .WithOne(oq => oq.CategoriesCatalog)
               .HasForeignKey(oq => oq.CategoriesCatalogId);
        }
    }
}