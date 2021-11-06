using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackTileBackend.Migrations
{
    public partial class IBeesQweenStateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acc_X",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "Acc_X_Neg",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "Acc_Y",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "Acc_Y_Neg",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "GpsStandBy",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "Gps_South",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "Gps_West",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "SigfoxDevices");

            migrationBuilder.RenameColumn(
                name: "Smoke_level",
                table: "SigfoxDevices",
                newName: "SmokeLevel");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Knock",
                table: "SigfoxDevices");

            migrationBuilder.DropColumn(
                name: "QueenState",
                table: "SigfoxDevices");

            migrationBuilder.RenameColumn(
                name: "SmokeLevel",
                table: "SigfoxDevices",
                newName: "Smoke_level");

            migrationBuilder.AddColumn<double>(
                name: "Acc_X",
                table: "SigfoxDevices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Acc_X_Neg",
                table: "SigfoxDevices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Acc_Y",
                table: "SigfoxDevices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Acc_Y_Neg",
                table: "SigfoxDevices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GpsStandBy",
                table: "SigfoxDevices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gps_South",
                table: "SigfoxDevices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gps_West",
                table: "SigfoxDevices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "SigfoxDevices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Long",
                table: "SigfoxDevices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
