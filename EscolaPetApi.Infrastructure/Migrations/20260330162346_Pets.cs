using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaPetApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Pets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tutors",
                table: "Tutors");

            migrationBuilder.RenameTable(
                name: "Tutors",
                newName: "Tutores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tutores",
                table: "Tutores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Especie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tutores",
                table: "Tutores");

            migrationBuilder.RenameTable(
                name: "Tutores",
                newName: "Tutors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tutors",
                table: "Tutors",
                column: "Id");
        }
    }
}
