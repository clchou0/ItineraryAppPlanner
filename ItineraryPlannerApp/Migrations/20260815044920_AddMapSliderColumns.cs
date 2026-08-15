using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItineraryPlannerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMapSliderColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Slider_DefX",
                table: "Cities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Slider_DefY",
                table: "Cities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Slider_MaxX",
                table: "Cities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Slider_MaxY",
                table: "Cities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Slider_MinX",
                table: "Cities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Slider_MinY",
                table: "Cities",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slider_DefX",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Slider_DefY",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Slider_MaxX",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Slider_MaxY",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Slider_MinX",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Slider_MinY",
                table: "Cities");
        }
    }
}
