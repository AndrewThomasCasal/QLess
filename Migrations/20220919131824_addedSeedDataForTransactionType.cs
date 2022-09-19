using Microsoft.EntityFrameworkCore.Migrations;

namespace QLess.Migrations
{
    public partial class addedSeedDataForTransactionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "Id", "TransactionTypeName" },
                values: new object[] { 1, "Load" });

            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "Id", "TransactionTypeName" },
                values: new object[] { 2, "Use" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
