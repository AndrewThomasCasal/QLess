using Microsoft.EntityFrameworkCore.Migrations;

namespace QLess.Migrations
{
    public partial class addinitialloadtocardtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "InitialLoad",
                table: "CardType",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialLoad",
                table: "CardType");
        }
    }
}
