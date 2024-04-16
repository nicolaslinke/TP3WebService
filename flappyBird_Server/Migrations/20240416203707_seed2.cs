using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flappyBird_Server.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6414cd54-1676-424a-86a1-e6bd6e5225c0", 0, "e7285b09-b053-4560-a777-5e59f0e57045", "lol@gmail.com", false, false, null, "LOL@GMAIL.COM", "ALLO", "AQAAAAEAACcQAAAAECpf5P8rUnIGRMn0DIi5tTdCS7NRbuLaG6ulQjhT5+fBqSVatIRr5F7DYGMRE23TCQ==", null, false, "ef37dc8d-9cdd-4148-a9ef-e886ea02818f", false, "allo" });

            migrationBuilder.InsertData(
                table: "Score",
                columns: new[] { "Id", "Pseudo", "UserId", "date", "isPublic", "scoreValue", "timeInSeconds" },
                values: new object[] { 1, "allo", null, "2024-04-16 16:37:07", true, 1, "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6414cd54-1676-424a-86a1-e6bd6e5225c0");

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
