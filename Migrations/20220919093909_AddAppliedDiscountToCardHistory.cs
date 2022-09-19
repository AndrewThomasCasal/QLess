using Microsoft.EntityFrameworkCore.Migrations;

namespace QLess.Migrations
{
    public partial class AddAppliedDiscountToCardHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AdditionalDiscountMaxUsePerDay",
                table: "CardType",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "AppliedDiscount",
                table: "CardHistory",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedDiscount",
                table: "CardHistory");

            migrationBuilder.AlterColumn<float>(
                name: "AdditionalDiscountMaxUsePerDay",
                table: "CardType",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
