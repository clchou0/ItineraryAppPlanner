using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItineraryPlannerApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    FlagPath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttractionName = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    Location_Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Location_Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    EntryPrice = table.Column<double>(type: "REAL", nullable: false),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attractions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArriveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalEntryPrice = table.Column<double>(type: "REAL", nullable: false),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itineraries_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accessibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    StationName = table.Column<string>(type: "TEXT", nullable: false),
                    MinuteWalk = table.Column<int>(type: "INTEGER", nullable: false),
                    AttractionId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttractionId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessibilities_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessibilities_Attractions_AttractionId1",
                        column: x => x.AttractionId1,
                        principalTable: "Attractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttractionLabel",
                columns: table => new
                {
                    AttractionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    AttractionId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionLabel", x => new { x.AttractionId, x.Category });
                    table.ForeignKey(
                        name: "FK_AttractionLabel_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttractionLabel_Attractions_AttractionId1",
                        column: x => x.AttractionId1,
                        principalTable: "Attractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItineraryBlock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ItineraryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    TotalDuration = table.Column<int>(type: "INTEGER", nullable: true),
                    AttractionId = table.Column<int>(type: "INTEGER", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryBlock_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItineraryBlock_Itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Method = table.Column<int>(type: "INTEGER", nullable: false),
                    route = table.Column<string>(type: "TEXT", nullable: false),
                    FromStation = table.Column<string>(type: "TEXT", nullable: false),
                    ToStation = table.Column<string>(type: "TEXT", nullable: false),
                    BlockId = table.Column<int>(type: "INTEGER", nullable: false),
                    TransportBlockId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportNotes_ItineraryBlock_BlockId",
                        column: x => x.BlockId,
                        principalTable: "ItineraryBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportNotes_ItineraryBlock_TransportBlockId",
                        column: x => x.TransportBlockId,
                        principalTable: "ItineraryBlock",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessibilities_AttractionId",
                table: "Accessibilities",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessibilities_AttractionId1",
                table: "Accessibilities",
                column: "AttractionId1");

            migrationBuilder.CreateIndex(
                name: "IX_AttractionLabel_AttractionId1",
                table: "AttractionLabel",
                column: "AttractionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_CityId",
                table: "Attractions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_CityId",
                table: "Itineraries",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryBlock_AttractionId",
                table: "ItineraryBlock",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryBlock_ItineraryId",
                table: "ItineraryBlock",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportNotes_BlockId",
                table: "TransportNotes",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportNotes_TransportBlockId",
                table: "TransportNotes",
                column: "TransportBlockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessibilities");

            migrationBuilder.DropTable(
                name: "AttractionLabel");

            migrationBuilder.DropTable(
                name: "TransportNotes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ItineraryBlock");

            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Itineraries");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
