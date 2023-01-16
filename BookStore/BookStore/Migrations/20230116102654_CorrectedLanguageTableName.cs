using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class CorrectedLanguageTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_languages_LanguageId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_languages",
                table: "languages");

            migrationBuilder.RenameTable(
                name: "languages",
                newName: "language");

            migrationBuilder.AddPrimaryKey(
                name: "PK_language",
                table: "language",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_language_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "language",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_language_LanguageId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_language",
                table: "language");

            migrationBuilder.RenameTable(
                name: "language",
                newName: "languages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_languages",
                table: "languages",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_languages_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
