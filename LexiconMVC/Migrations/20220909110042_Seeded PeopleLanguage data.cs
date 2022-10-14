using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class SeededPeopleLanguagedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguagesListId", "PeopleListId" },
                values: new object[,]
                {
                    { -4, -3 },
                    { -3, -2 },
                    { -2, -1 },
                    { -1, -1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesListId", "PeopleListId" },
                keyValues: new object[] { -4, -3 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesListId", "PeopleListId" },
                keyValues: new object[] { -3, -2 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesListId", "PeopleListId" },
                keyValues: new object[] { -2, -1 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesListId", "PeopleListId" },
                keyValues: new object[] { -1, -1 });
        }
    }
}
