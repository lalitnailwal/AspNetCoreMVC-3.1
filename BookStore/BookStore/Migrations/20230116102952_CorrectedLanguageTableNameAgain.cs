using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class CorrectedLanguageTableNameAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_language_LanguageId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_language",
                table: "language");

            migrationBuilder.RenameTable(
                name: "language",
                newName: "Language");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Language_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Language_LanguageId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Language",
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
    }
}
