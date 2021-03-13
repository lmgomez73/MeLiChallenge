using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MeliChallenge.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Satellites",
                columns: table => new
                {
                    IdSatelite = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PositionY = table.Column<double>(type: "double precision", nullable: false),
                    PositionX = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satellites", x => x.IdSatelite);
                });

            migrationBuilder.InsertData(
                table: "Satellites",
                columns: new[] { "IdSatelite", "Name", "PositionX", "PositionY" },
                values: new object[,]
                {
                    { 1, "Kenobi", -500.0, -200.0 },
                    { 2, "Skywalker", 100.0, -100.0 },
                    { 3, "Sato", 500.0, 100.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Satellites");
        }
    }
}
