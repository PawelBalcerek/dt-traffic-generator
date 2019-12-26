using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InsertEndpoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Endpoints\"", true);
            migrationBuilder.InsertData(
                table: "Endpoints",
                columns: new[] { "EndpointId", "EndpointName", "HttpMethod" },
                values: new object[,]
                {
                    { 1L, "UserGetInfo", "GET" },
                    { 2L, "UserRegister", "POST" },
                    { 3L, "UserLogin", "POST" },
                    { 4L, "UserLogout", "GET" },
                    { 5L, "CompaniesShow", "GET" },
                    { 6L, "CompaniesAdd", "POST" },
                    { 7L, "ResourcesShow", "GET" },
                    { 8L, "SellOffersShow", "GET" },
                    { 9L, "SellOffersAdd", "POST" },
                    { 10L, "SellOffersWithdraw", "GET" },
                    { 11L, "BuyOffersShow", "GET" },
                    { 12L, "BuyOffersAdd", "POST" },
                    { 13L, "BuyOffersWithdraw", "GET" },
                    { 14L, "TransactionsShow", "GET" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Endpoints",
                keyColumn: "EndpointId",
                keyValue: 14L);
        }
    }
}
