namespace Domain.Entities
{
    public class OptionsResponse : BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? OptionText { get; set; }

        public List<CategoryOptions> CategoryOptions { get; set; } = new List<CategoryOptions>();
        public List<OptionQuestions> OptionQuestions { get; set; } = new List<OptionQuestions>();
    }
}