using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItineraryPlannerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTransitRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "route",
                table: "TransportNotes",
                newName: "Route");

            migrationBuilder.CreateTable(
                name: "TransitRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    RouteName = table.Column<string>(type: "TEXT", nullable: false),
                    CityName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransitRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransitStops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StopName = table.Column<string>(type: "TEXT", nullable: false),
                    StopOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    TransitRouteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransitStops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransitStops_TransitRoutes_TransitRouteId",
                        column: x => x.TransitRouteId,
                        principalTable: "TransitRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransitStops_TransitRouteId",
                table: "TransitStops",
                column: "TransitRouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransitStops");

            migrationBuilder.DropTable(
                name: "TransitRoutes");

            migrationBuilder.RenameColumn(
                name: "Route",
                table: "TransportNotes",
                newName: "route");
        }
    }
}
