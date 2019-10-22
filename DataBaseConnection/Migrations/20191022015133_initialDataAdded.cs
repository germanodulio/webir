using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class initialDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
