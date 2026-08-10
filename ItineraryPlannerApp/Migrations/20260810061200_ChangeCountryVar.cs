using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItineraryPlannerApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCountryVar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlagPath",
                table: "Cities",
                newName: "Country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Cities",
                newName: "FlagPath");
        }
    }
}
