using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoofHub_App.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoDeReportAbandoment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbandonmentReport_Adress_AdressId",
                table: "AbandonmentReport");

            migrationBuilder.DropIndex(
                name: "IX_AbandonmentReport_AdressId",
                table: "AbandonmentReport");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "AbandonmentReport");

            migrationBuilder.AddColumn<int>(
                name: "AbandonmentId",
                table: "Adress",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adress_AbandonmentId",
                table: "Adress",
                column: "AbandonmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_AbandonmentReport_AbandonmentId",
                table: "Adress",
                column: "AbandonmentId",
                principalTable: "AbandonmentReport",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_AbandonmentReport_AbandonmentId",
                table: "Adress");

            migrationBuilder.DropIndex(
                name: "IX_Adress_AbandonmentId",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "AbandonmentId",
                table: "Adress");

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "AbandonmentReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AbandonmentReport_AdressId",
                table: "AbandonmentReport",
                column: "AdressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbandonmentReport_Adress_AdressId",
                table: "AbandonmentReport",
                column: "AdressId",
                principalTable: "Adress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
