using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackTileBackend.Migrations
{
    public partial class SigFoxDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Knock",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "QueenState",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "SmokeLevel",
                table: "SigfoxDevices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Knock",
                table: "SigfoxDevices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QueenState",
                table: "SigfoxDevices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SmokeLevel",
                table: "SigfoxDevices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
