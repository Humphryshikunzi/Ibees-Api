﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackTileBackend.Migrations
{
    public partial class SmokeLevelTTnMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Smoke_level",
                table: "Fields",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Smoke_level",
                table: "Fields");
        }
    }
}
