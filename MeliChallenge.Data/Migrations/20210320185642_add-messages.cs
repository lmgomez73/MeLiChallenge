using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MeliChallenge.Data.Migrations
{
    public partial class addmessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    IdMessage = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MessageResult = table.Column<string>(type: "text", nullable: true),
                    ReceivedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.IdMessage);
                });

            migrationBuilder.CreateTable(
                name: "MessageItems",
                columns: table => new
                {
                    IdMessageItem = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SatelliteIdSatelite = table.Column<int>(type: "integer", nullable: true),
                    Phrases = table.Column<string[]>(type: "text[]", nullable: true),
                    MessageIdMessage = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageItems", x => x.IdMessageItem);
                    table.ForeignKey(
                        name: "FK_MessageItems_Messages_MessageIdMessage",
                        column: x => x.MessageIdMessage,
                        principalTable: "Messages",
                        principalColumn: "IdMessage",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageItems_Satellites_SatelliteIdSatelite",
                        column: x => x.SatelliteIdSatelite,
                        principalTable: "Satellites",
                        principalColumn: "IdSatelite",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageItems_MessageIdMessage",
                table: "MessageItems",
                column: "MessageIdMessage");

            migrationBuilder.CreateIndex(
                name: "IX_MessageItems_SatelliteIdSatelite",
                table: "MessageItems",
                column: "SatelliteIdSatelite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageItems");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
