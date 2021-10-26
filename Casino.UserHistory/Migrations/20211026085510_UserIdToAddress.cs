using Microsoft.EntityFrameworkCore.Migrations;

namespace Casino.UserHistory.Migrations
{
    public partial class UserIdToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Address");
        }
    }
}
