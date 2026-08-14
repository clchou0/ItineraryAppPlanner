using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItineraryPlannerApp.Migrations
{
    /// <inheritdoc />
    public partial class FixTransportNoteRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportNotes_TransportBlocks_TransportBlockId",
                table: "TransportNotes");

            migrationBuilder.DropIndex(
                name: "IX_TransportNotes_TransportBlockId",
                table: "TransportNotes");

            migrationBuilder.DropColumn(
                name: "TransportBlockId",
                table: "TransportNotes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransportBlockId",
                table: "TransportNotes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportNotes_TransportBlockId",
                table: "TransportNotes",
                column: "TransportBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportNotes_TransportBlocks_TransportBlockId",
                table: "TransportNotes",
                column: "TransportBlockId",
                principalTable: "TransportBlocks",
                principalColumn: "Id");
        }
    }
}
