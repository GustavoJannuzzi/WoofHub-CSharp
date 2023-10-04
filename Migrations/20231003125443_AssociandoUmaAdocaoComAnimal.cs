using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoofHub_App.Migrations
{
    /// <inheritdoc />
    public partial class AssociandoUmaAdocaoComAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Adoption",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_AnimalId",
                table: "Adoption",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoption_Animal_AnimalId",
                table: "Adoption",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoption_Animal_AnimalId",
                table: "Adoption");

            migrationBuilder.DropIndex(
                name: "IX_Adoption_AnimalId",
                table: "Adoption");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Adoption");
        }
    }
}
