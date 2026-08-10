using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItineraryPlannerApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedVarTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Cities_CityId1",
                table: "Attractions");

            migrationBuilder.DropIndex(
                name: "IX_Attractions_CityId1",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Attractions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Attractions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_CityId1",
                table: "Attractions",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Cities_CityId1",
                table: "Attractions",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
