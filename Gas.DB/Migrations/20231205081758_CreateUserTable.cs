using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gas.DB.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Stations_StationId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Locations_LocationId",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Types_TypeId",
                table: "Prices");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_LocationId",
                table: "Prices",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_TypeId",
                table: "Prices",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_StationId",
                table: "Locations",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Stations_StationId",
                table: "Locations",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Locations_LocationId",
                table: "Prices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Types_TypeId",
                table: "Prices",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Stations_StationId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Locations_LocationId",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Types_TypeId",
                table: "Prices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Prices_LocationId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_TypeId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Locations_StationId",
                table: "Locations");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Stations_StationId",
                table: "Locations",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Locations_LocationId",
                table: "Prices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Types_TypeId",
                table: "Prices",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
