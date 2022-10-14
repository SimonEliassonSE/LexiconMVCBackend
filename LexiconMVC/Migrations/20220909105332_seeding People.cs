using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class seedingPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CityId", "Name", "Phonenumber" },
                values: new object[,]
                {
                    { -10, -9, "Charlie Svensson", 778852211 },
                    { -9, -8, "Andy Karlsson", 778852211 },
                    { -8, -7, "Frida Svensson", 778852211 },
                    { -7, -6, "Sara Strand", 761496378 },
                    { -6, -5, "Björn Bergman", 759982251 },
                    { -5, -4, "Andy Hjert", 738660102 },
                    { -4, -3, "Kalle Carlsson", 741237894 },
                    { -3, -2, "Annie Svensson", 782161234 },
                    { -2, -10, "Janne Karlsson", 709952132 },
                    { -1, -1, "Simon Eliasson", 738450197 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
