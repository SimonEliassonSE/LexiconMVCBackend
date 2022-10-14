using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class AddedrolesandAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cea907d-71c6-4d71-a28d-b2ef0d90ab55", "81e5f9b6-b376-44c9-86bd-1de5ad86685a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3e611d8-4821-4061-94c6-5f03067f60e0", "a4c90aba-8364-43be-94a1-f2daebcd6c1e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e14a19fa-fdc2-4651-b9f9-4c4d5bb2d008", 0, "1800-01-01", "7a5fa67a-782e-418b-9c08-9dbaf80e7763", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIIN.COM", "AQAAAAEAACcQAAAAEFHTSN0QzWQXZwsQbqdTFRYZ+sZ2NkqtxRvhBCrCOpKj1df5eceWOlpwPv8cVZGTug==", null, false, "4a51124b-90d8-4ec6-9a40-1fb4dfb77fe5", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b3e611d8-4821-4061-94c6-5f03067f60e0", "e14a19fa-fdc2-4651-b9f9-4c4d5bb2d008" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cea907d-71c6-4d71-a28d-b2ef0d90ab55");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b3e611d8-4821-4061-94c6-5f03067f60e0", "e14a19fa-fdc2-4651-b9f9-4c4d5bb2d008" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3e611d8-4821-4061-94c6-5f03067f60e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e14a19fa-fdc2-4651-b9f9-4c4d5bb2d008");
        }
    }
}
