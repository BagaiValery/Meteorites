using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meteorites.Migrations
{
    /// <inheritdoc />
    public partial class DbId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meteorites_GeoDB_geolocationId",
                table: "Meteorites");

            migrationBuilder.RenameColumn(
                name: "geolocationId",
                table: "Meteorites",
                newName: "geolocDBId");

            migrationBuilder.RenameIndex(
                name: "IX_Meteorites_geolocationId",
                table: "Meteorites",
                newName: "IX_Meteorites_geolocDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meteorites_GeoDB_geolocDBId",
                table: "Meteorites",
                column: "geolocDBId",
                principalTable: "GeoDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meteorites_GeoDB_geolocDBId",
                table: "Meteorites");

            migrationBuilder.RenameColumn(
                name: "geolocDBId",
                table: "Meteorites",
                newName: "geolocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Meteorites_geolocDBId",
                table: "Meteorites",
                newName: "IX_Meteorites_geolocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meteorites_GeoDB_geolocationId",
                table: "Meteorites",
                column: "geolocationId",
                principalTable: "GeoDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
