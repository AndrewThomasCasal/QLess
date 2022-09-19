using Microsoft.EntityFrameworkCore.Migrations;

namespace QLess.Migrations
{
    public partial class AddedSeniorCitizenNumAndPWDNumToCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PWDNum",
                table: "Card",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeniorCitizenNum",
                table: "Card",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PWDNum",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "SeniorCitizenNum",
                table: "Card");
        }
    }
}
