using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManageApp.Migrations
{
    public partial class Initial_Update9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_owngoal",
                table: "score",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_owngoal",
                table: "score");
        }
    }
}
