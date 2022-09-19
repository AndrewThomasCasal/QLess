using Microsoft.EntityFrameworkCore.Migrations;

namespace QLess.Migrations
{
    public partial class AddedValidityPeriodToCardType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValidityPeriod",
                table: "CardType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidityPeriod",
                table: "CardType");
        }
    }
}
