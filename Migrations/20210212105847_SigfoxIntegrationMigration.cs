using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackTileBackend.Migrations
{
    public partial class SigfoxIntegrationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SigfoxDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Device = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false),
                    Acc_X = table.Column<double>(type: "float", nullable: false),
                    Acc_Y = table.Column<double>(type: "float", nullable: false),
                    Temp = table.Column<double>(type: "float", nullable: false),
                    Hum = table.Column<double>(type: "float", nullable: false),
                    Acc_X_Neg = table.Column<bool>(type: "bit", nullable: false),
                    Acc_Y_Neg = table.Column<bool>(type: "bit", nullable: false),
                    GpsStandBy = table.Column<bool>(type: "bit", nullable: false),
                    Gps_South = table.Column<bool>(type: "bit", nullable: false),
                    Gps_West = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SigfoxDevices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SigfoxDevices");
        }
    }
}
