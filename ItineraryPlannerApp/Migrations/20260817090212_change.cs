using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItineraryPlannerApp.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransitAccess_Attractions_AttractionId1",
                table: "TransitAccess");

            migrationBuilder.DropIndex(
                name: "IX_TransitAccess_AttractionId1",
                table: "TransitAccess");

            migrationBuilder.DropColumn(
                name: "AttractionId1",
                table: "TransitAccess");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttractionId1",
                table: "TransitAccess",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransitAccess_AttractionId1",
                table: "TransitAccess",
                column: "AttractionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TransitAccess_Attractions_AttractionId1",
                table: "TransitAccess",
                column: "AttractionId1",
                principalTable: "Attractions",
                principalColumn: "Id");
        }
    }
}
