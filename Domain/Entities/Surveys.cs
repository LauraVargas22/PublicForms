namespace Domain.Entities
{
    public class Surveys : BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? ComponentHtml { get; set; }
        public string? ComponentReact { get; set; }
        public string? Description { get; set; }
        public string? Instruction { get; set; }
        public string? Name { get; set; }

        public List<SumaryOptions> SumaryOptions { get; set; } = new List<SumaryOptions>();
        public List<Chapters> Chapters { get; set; } = new List<Chapters>();
    }
}