namespace Domain.Entities
{
    public class SumaryOptions
    {
        public int Id { get; set; }
        public string? CodeNumber { get; set; }
        public string? Valuerta { get; set; }
        public int QuestionId { get; set; }
        public Questions? Questions { get; set; }

        public int SurveyId { get; set; }
        public Surveys? Surveys { get; set; }
    }
}