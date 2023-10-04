using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoofHub_App.Migrations
{
    /// <inheritdoc />
    public partial class AssociandoUmaAdocaoComCLient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situation",
                table: "Adoption");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Adoption",
                newName: "DateAdoption");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Adoption",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_ClientId",
                table: "Adoption",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoption_Client_ClientId",
                table: "Adoption",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoption_Client_ClientId",
                table: "Adoption");

            migrationBuilder.DropIndex(
                name: "IX_Adoption_ClientId",
                table: "Adoption");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Adoption");

            migrationBuilder.RenameColumn(
                name: "DateAdoption",
                table: "Adoption",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Situation",
                table: "Adoption",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
