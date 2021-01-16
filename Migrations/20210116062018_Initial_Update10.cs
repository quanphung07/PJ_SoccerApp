using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManageApp.Migrations
{
    public partial class Initial_Update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "creator_id",
                table: "team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_team_creator_id",
                table: "team",
                column: "creator_id");

            migrationBuilder.AddForeignKey(
                name: "FK_team_AspNetUsers_creator_id",
                table: "team",
                column: "creator_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_team_AspNetUsers_creator_id",
                table: "team");

            migrationBuilder.DropIndex(
                name: "IX_team_creator_id",
                table: "team");

            migrationBuilder.DropColumn(
                name: "creator_id",
                table: "team");
        }
    }
}
