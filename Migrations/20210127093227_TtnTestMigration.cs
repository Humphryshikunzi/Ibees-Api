using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackTileBackend.Migrations
{
    public partial class TtnTestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Helps");

            migrationBuilder.CreateTable(
                name: "gateways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gtw_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timestamp = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    channel = table.Column<int>(type: "int", nullable: false),
                    rssi = table.Column<int>(type: "int", nullable: false),
                    snr = table.Column<int>(type: "int", nullable: false),
                    rf_chain = table.Column<int>(type: "int", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    altitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gateways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "payload_fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    temperature_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    relative_humidity_3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payload_fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    frequency = table.Column<double>(type: "float", nullable: false),
                    modulation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bit_rate = table.Column<int>(type: "int", nullable: false),
                    coding_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gatewaysId = table.Column<int>(type: "int", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    altitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_metadata_gateways_gatewaysId",
                        column: x => x.gatewaysId,
                        principalTable: "gateways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TttnTestData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    app_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dev_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hardware_serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    port = table.Column<int>(type: "int", nullable: false),
                    counter = table.Column<int>(type: "int", nullable: false),
                    is_retry = table.Column<bool>(type: "bit", nullable: false),
                    confirmed = table.Column<bool>(type: "bit", nullable: false),
                    payload_raw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payload_fieldsId = table.Column<int>(type: "int", nullable: true),
                    metadataId = table.Column<int>(type: "int", nullable: true),
                    downlink_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TttnTestData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TttnTestData_metadata_metadataId",
                        column: x => x.metadataId,
                        principalTable: "metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TttnTestData_payload_fields_payload_fieldsId",
                        column: x => x.payload_fieldsId,
                        principalTable: "payload_fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_metadata_gatewaysId",
                table: "metadata",
                column: "gatewaysId");

            migrationBuilder.CreateIndex(
                name: "IX_TttnTestData_metadataId",
                table: "TttnTestData",
                column: "metadataId");

            migrationBuilder.CreateIndex(
                name: "IX_TttnTestData_payload_fieldsId",
                table: "TttnTestData",
                column: "payload_fieldsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TttnTestData");

            migrationBuilder.DropTable(
                name: "metadata");

            migrationBuilder.DropTable(
                name: "payload_fields");

            migrationBuilder.DropTable(
                name: "gateways");

            migrationBuilder.CreateTable(
                name: "Helps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HelpLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HelpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helps", x => x.Id);
                });
        }
    }
}
