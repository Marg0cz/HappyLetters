using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyLetters.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "Answer", "LetterRiddles", "Solution");

            migrationBuilder.DeleteData(
                table: "LetterRiddles",
                keyColumn: "Guid",
                keyValue: new Guid("fa5283ef-c8bb-472d-ba47-6e87242ea727"));

            migrationBuilder.InsertData(
                table: "LetterRiddles",
                columns: new[] { "Guid", "Content", "Solution" },
                values: new object[] { new Guid("a3429643-fc11-4ccf-88dd-c061d50b75ba"), "A", "A" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LetterRiddles",
                keyColumn: "Guid",
                keyValue: new Guid("a3429643-fc11-4ccf-88dd-c061d50b75ba"));

            migrationBuilder.InsertData(
                table: "LetterRiddles",
                columns: new[] { "Guid", "Content", "Solution" },
                values: new object[] { new Guid("fa5283ef-c8bb-472d-ba47-6e87242ea727"), "A", null });
        }
    }
}
