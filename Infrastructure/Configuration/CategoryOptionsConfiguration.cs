using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CategoryOptionsConfiguration : IEntityTypeConfiguration<CategoryOptions>
    {
        public void Configure(EntityTypeBuilder<CategoryOptions> builder)
        {
            builder.ToTable("category_options");
            builder.HasKey(co => co.Id);
            builder.Property(co => co.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(co => co.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(co => co.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(co => co.CatalogOptionsId)
                .IsRequired()
                .HasColumnName("catalogoptions_id");

            builder.Property(co => co.CategoriesOptionsId)
                .IsRequired()
                .HasColumnName("categoriesoptions_id");
        }
    }
}