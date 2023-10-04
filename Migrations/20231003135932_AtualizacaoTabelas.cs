using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoofHub_App.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalModelId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_AnimalModelId",
                table: "Client",
                column: "AnimalModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Animal_AnimalModelId",
                table: "Client",
                column: "AnimalModelId",
                principalTable: "Animal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Animal_AnimalModelId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_AnimalModelId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "AnimalModelId",
                table: "Client");
        }
    }
}
