using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class foreignKeyExplicit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Currencies_CoinRefCode",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_CoinRefCode",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "CoinRefCode",
                table: "Quotations");

            migrationBuilder.AddColumn<int>(
                name: "RefCode",
                table: "Quotations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_RefCode",
                table: "Quotations",
                column: "RefCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Currencies_RefCode",
                table: "Quotations",
                column: "RefCode",
                principalTable: "Currencies",
                principalColumn: "RefCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Currencies_RefCode",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_RefCode",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "RefCode",
                table: "Quotations");

            migrationBuilder.AddColumn<int>(
                name: "CoinRefCode",
                table: "Quotations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CoinRefCode",
                table: "Quotations",
                column: "CoinRefCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Currencies_CoinRefCode",
                table: "Quotations",
                column: "CoinRefCode",
                principalTable: "Currencies",
                principalColumn: "RefCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
