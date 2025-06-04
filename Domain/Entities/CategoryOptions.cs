namespace Domain.Entities
{
    public class CategoryOptions
    {
        public int Id { get; set; }
        public int CatalogOptionsId { get; set; }
        public int CategoriesOptionsId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int OptionsResponseId { get; set; }
        public OptionsResponse? OptionsResponse { get; set; }

        public int CategoriesCatalogId { get; set; }
        public CategoriesCatalog? CategoriesCatalog { get; set; }
    }
}