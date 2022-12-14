using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyLetters.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LetterRiddles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Answer = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterRiddles", x => x.Guid);
                });

            migrationBuilder.InsertData(
                table: "LetterRiddles",
                columns: new[] { "Guid", "Solution", "Content" },
                values: new object[] { new Guid("fa5283ef-c8bb-472d-ba47-6e87242ea727"), "A", "A" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LetterRiddles");
        }
    }
}
