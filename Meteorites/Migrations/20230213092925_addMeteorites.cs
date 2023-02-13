using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meteorites.Migrations
{
    /// <inheritdoc />
    public partial class addMeteorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coordinateX = table.Column<float>(type: "real", nullable: false),
                    coordinateY = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meteorites",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nametype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recclass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mass = table.Column<float>(type: "real", nullable: true),
                    fall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reclat = table.Column<float>(type: "real", nullable: true),
                    reclong = table.Column<float>(type: "real", nullable: true),
                    geolocationId = table.Column<int>(type: "int", nullable: false),
                    computedregioncbhkfwbd = table.Column<int>(name: "computed_region_cbhk_fwbd", type: "int", nullable: true),
                    computedregionnnqa25f4 = table.Column<int>(name: "computed_region_nnqa_25f4", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meteorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_Meteorites_GeoDB_geolocationId",
                        column: x => x.geolocationId,
                        principalTable: "GeoDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meteorites_geolocationId",
                table: "Meteorites",
                column: "geolocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meteorites");

            migrationBuilder.DropTable(
                name: "GeoDB");
        }
    }
}
