using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories_catalogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories_catalogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "options_responses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    option_text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options_responses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "surveys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    componenthtml = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    componentreact = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    instruction = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    catalogoptions_id = table.Column<int>(type: "integer", nullable: false),
                    categoriesoptions_id = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 290, DateTimeKind.Utc).AddTicks(5267)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 294, DateTimeKind.Utc).AddTicks(4240)),
                    OptionsResponseId = table.Column<int>(type: "integer", nullable: false),
                    CategoriesCatalogId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_options_categories_catalogs_categoriesoptions_id",
                        column: x => x.categoriesoptions_id,
                        principalTable: "categories_catalogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_category_options_options_responses_OptionsResponseId",
                        column: x => x.OptionsResponseId,
                        principalTable: "options_responses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chapters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    componenthtml = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    componentreact = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    chapter_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    chapter_title = table.Column<string>(type: "text", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapters", x => x.id);
                    table.ForeignKey(
                        name: "FK_chapters_surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "surveys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    question_number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    response_type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    comment_question = table.Column<string>(type: "text", nullable: true),
                    question_text = table.Column<string>(type: "text", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questions_chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "chapters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sub_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    subquestion_number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    comment_subquestion = table.Column<string>(type: "text", nullable: true),
                    subquestion_text = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_sub_questions_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sumary_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    valuerta = table.Column<string>(type: "text", nullable: true),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sumary_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_sumary_options_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sumary_options_surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "surveys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "option_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 302, DateTimeKind.Utc).AddTicks(4100)),
                    option_id = table.Column<int>(type: "integer", nullable: false),
                    optioncatalog_id = table.Column<int>(type: "integer", nullable: false),
                    optionquestion_id = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 302, DateTimeKind.Utc).AddTicks(4810)),
                    comment_optionres = table.Column<string>(type: "text", nullable: true),
                    number_option = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    SubquestionId = table.Column<int>(type: "integer", nullable: false),
                    CategoriesCatalogId = table.Column<int>(type: "integer", nullable: false),
                    OptionsResponseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_option_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_option_questions_categories_catalogs_CategoriesCatalogId",
                        column: x => x.CategoriesCatalogId,
                        principalTable: "categories_catalogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_option_questions_options_responses_OptionsResponseId",
                        column: x => x.OptionsResponseId,
                        principalTable: "options_responses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_option_questions_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_option_questions_sub_questions_SubquestionId",
                        column: x => x.SubquestionId,
                        principalTable: "sub_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_options_categoriesoptions_id",
                table: "category_options",
                column: "categoriesoptions_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_options_OptionsResponseId",
                table: "category_options",
                column: "OptionsResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_chapters_SurveyId",
                table: "chapters",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_option_questions_CategoriesCatalogId",
                table: "option_questions",
                column: "CategoriesCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_option_questions_OptionsResponseId",
                table: "option_questions",
                column: "OptionsResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_option_questions_QuestionId",
                table: "option_questions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_option_questions_SubquestionId",
                table: "option_questions",
                column: "SubquestionId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_ChapterId",
                table: "questions",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_sub_questions_QuestionId",
                table: "sub_questions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_sumary_options_QuestionId",
                table: "sumary_options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_sumary_options_SurveyId",
                table: "sumary_options",
                column: "SurveyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category_options");

            migrationBuilder.DropTable(
                name: "option_questions");

            migrationBuilder.DropTable(
                name: "sumary_options");

            migrationBuilder.DropTable(
                name: "categories_catalogs");

            migrationBuilder.DropTable(
                name: "options_responses");

            migrationBuilder.DropTable(
                name: "sub_questions");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "chapters");

            migrationBuilder.DropTable(
                name: "surveys");
        }
    }
}
