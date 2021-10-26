using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TickerPreviousCloseHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(nullable: true),
                    Close = table.Column<double>(nullable: false),
                    Highest = table.Column<double>(nullable: false),
                    Lowest = table.Column<double>(nullable: false),
                    Open = table.Column<double>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    VolumeWeightedAveragePrice = table.Column<double>(nullable: false),
                    Timestamp = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TickerPreviousCloseHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TickerPreviousCloseHistory");
        }
    }
}
