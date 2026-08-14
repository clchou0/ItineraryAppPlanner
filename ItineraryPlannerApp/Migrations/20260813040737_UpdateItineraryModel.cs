using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItineraryPlannerApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItineraryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItineraryBlock_Itineraries_ItineraryId",
                table: "ItineraryBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportBlocks_ItineraryBlock_Id",
                table: "TransportBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitBlocks_ItineraryBlock_Id",
                table: "VisitBlocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItineraryBlock",
                table: "ItineraryBlock");

            migrationBuilder.RenameTable(
                name: "ItineraryBlock",
                newName: "ItineraryBlocks");

            migrationBuilder.RenameIndex(
                name: "IX_ItineraryBlock_ItineraryId",
                table: "ItineraryBlocks",
                newName: "IX_ItineraryBlocks_ItineraryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItineraryBlocks",
                table: "ItineraryBlocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItineraryBlocks_Itineraries_ItineraryId",
                table: "ItineraryBlocks",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportBlocks_ItineraryBlocks_Id",
                table: "TransportBlocks",
                column: "Id",
                principalTable: "ItineraryBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitBlocks_ItineraryBlocks_Id",
                table: "VisitBlocks",
                column: "Id",
                principalTable: "ItineraryBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItineraryBlocks_Itineraries_ItineraryId",
                table: "ItineraryBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportBlocks_ItineraryBlocks_Id",
                table: "TransportBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitBlocks_ItineraryBlocks_Id",
                table: "VisitBlocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItineraryBlocks",
                table: "ItineraryBlocks");

            migrationBuilder.RenameTable(
                name: "ItineraryBlocks",
                newName: "ItineraryBlock");

            migrationBuilder.RenameIndex(
                name: "IX_ItineraryBlocks_ItineraryId",
                table: "ItineraryBlock",
                newName: "IX_ItineraryBlock_ItineraryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItineraryBlock",
                table: "ItineraryBlock",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItineraryBlock_Itineraries_ItineraryId",
                table: "ItineraryBlock",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportBlocks_ItineraryBlock_Id",
                table: "TransportBlocks",
                column: "Id",
                principalTable: "ItineraryBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitBlocks_ItineraryBlock_Id",
                table: "VisitBlocks",
                column: "Id",
                principalTable: "ItineraryBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
