using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDateTimeDefaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "option_questions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 302, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "option_questions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 302, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "category_options",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 294, DateTimeKind.Utc).AddTicks(4240));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "category_options",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 290, DateTimeKind.Utc).AddTicks(5267));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "option_questions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 302, DateTimeKind.Utc).AddTicks(4810),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "option_questions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 302, DateTimeKind.Utc).AddTicks(4100),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "category_options",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 294, DateTimeKind.Utc).AddTicks(4240),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "category_options",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 4, 1, 32, 8, 290, DateTimeKind.Utc).AddTicks(5267),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
