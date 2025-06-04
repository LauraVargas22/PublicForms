namespace Domain.Entities
{
    public class SubQuestions
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? SubquestionNumber { get; set; }
        public string? CommentSubQuestion { get; set; }
        public string? SubquestionText { get; set; }

        public List<OptionQuestions> OptionQuestions { get; set; } = new List<OptionQuestions>();

        public int QuestionId { get; set; }
        public Questions? Questions { get; set; }
    }
}