namespace Domain.Entities
{
    public class Chapters
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? ComponentHtml { get; set; }
        public string? ComponentReact { get; set; }
        public string? ChapterNumber { get; set; }
        public string? ChapterTitle { get; set; }

        public List<Questions> Questions { get; set; } = new List<Questions>();
        public int SurveyId { get; set; }
        public Surveys? Surveys { get; set; }
    }
}