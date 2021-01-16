using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManageApp.Migrations
{
    public partial class Initial_Update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "round",
                table: "match",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "round",
                table: "match");
        }
    }
}
