namespace Domain.Entities
{
    public class CategoriesCatalog
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }

        public List<CategoryOptions> CategoryOptions { get; set; } = new List<CategoryOptions>();
        public List<OptionQuestions> OptionQuestions { get; set; } = new List<OptionQuestions>();
    }
}