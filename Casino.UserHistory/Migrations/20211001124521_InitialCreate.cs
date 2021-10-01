using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Casino.UserHistory.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpinHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    StartingBalance = table.Column<double>(nullable: false),
                    EndBalance = table.Column<double>(nullable: false),
                    Won = table.Column<bool>(nullable: false),
                    BetAmmount = table.Column<double>(nullable: false),
                    Winnings = table.Column<double>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpinHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpinHistory");
        }
    }
}
