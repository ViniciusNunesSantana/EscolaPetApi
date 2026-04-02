using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaPetApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EscolaId",
                table: "Tutores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tutores_EscolaId",
                table: "Tutores",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TutorId",
                table: "Pets",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Tutores_TutorId",
                table: "Pets",
                column: "TutorId",
                principalTable: "Tutores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutores_EscolaPets_EscolaId",
                table: "Tutores",
                column: "EscolaId",
                principalTable: "EscolaPets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Tutores_TutorId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutores_EscolaPets_EscolaId",
                table: "Tutores");

            migrationBuilder.DropIndex(
                name: "IX_Tutores_EscolaId",
                table: "Tutores");

            migrationBuilder.DropIndex(
                name: "IX_Pets_TutorId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "EscolaId",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Pets");
        }
    }
}
