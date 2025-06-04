namespace Domain.Entities
{
    public class OptionQuestions : BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OptionId { get; set; }
        public int OptionCatalogId { get; set; }
        public int OptionQuestionId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CommentOptionres { get; set; }
        public string? NumberOption { get; set; }

        public int QuestionId { get; set; }
        public Questions? Questions { get; set; }

        public int SubquestionId { get; set; }
        public SubQuestions? SubQuestions { get; set; }

        public int CategoriesCatalogId { get; set; }
        public CategoriesCatalog? CategoriesCatalog { get; set; }

        public int OptionsResponseId { get; set; }
        public OptionsResponse? OptionsResponse { get; set; }
    }
}