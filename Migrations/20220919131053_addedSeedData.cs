using Microsoft.EntityFrameworkCore.Migrations;

namespace QLess.Migrations
{
    public partial class addedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CardType",
                columns: new[] { "Id", "AdditionalDiscount", "AdditionalDiscountMaxUsePerDay", "BaseDiscount", "CardTypeName", "InitialLoad", "RegularRate", "ValidityPeriod" },
                values: new object[] { 1, 0f, 0, 0f, "Regular", 100f, 15f, 5 });

            migrationBuilder.InsertData(
                table: "CardType",
                columns: new[] { "Id", "AdditionalDiscount", "AdditionalDiscountMaxUsePerDay", "BaseDiscount", "CardTypeName", "InitialLoad", "RegularRate", "ValidityPeriod" },
                values: new object[] { 2, 0.03f, 4, 0.2f, "Discounted", 500f, 10f, 3 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "EmailAddress", "Firstname", "Lastname", "Password" },
                values: new object[] { 1, "Admin@Test.com", "Admin", "istrator", "1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CardType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CardType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
