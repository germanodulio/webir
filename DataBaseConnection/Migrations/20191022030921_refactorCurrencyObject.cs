using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class refactorCurrencyObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Currencies_CoinId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_CoinId",
                table: "Quotations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CoinId",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Currencies");

            migrationBuilder.AddColumn<int>(
                name: "CoinRefCode",
                table: "Quotations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "RefCode");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "RefCode",
                keyValue: 1,
                columns: new[] { "CountryBank", "Name" },
                values: new object[] { "Uruguay", "Dolar Uy" });

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "RefCode",
                keyValue: 2,
                column: "Name",
                value: "Dolar Oficial");

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "RefCode", "CountryBank", "Name" },
                values: new object[,]
                {
                    { 3, "Argentina", "Dolar Blue" },
                    { 0, "Uruguay", "Peso Argentino" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Currencies_CoinRefCode",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_CoinRefCode",
                table: "Quotations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "RefCode",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "RefCode",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "RefCode",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "RefCode",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CoinRefCode",
                table: "Quotations");

            migrationBuilder.AddColumn<int>(
                name: "CoinId",
                table: "Quotations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Currencies",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CountryBank", "Name", "RefCode" },
                values: new object[,]
                {
                    { 1, "Argentina", "Dolar Oficial", 1 },
                    { 2, "Argentina", "Dolar Blue", 2 },
                    { 3, "Uruguay", "Dolar Uy", 2222 },
                    { 4, "Uruguay", "Peso Argentino", 500 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CoinId",
                table: "Quotations",
                column: "CoinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Currencies_CoinId",
                table: "Quotations",
                column: "CoinId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
