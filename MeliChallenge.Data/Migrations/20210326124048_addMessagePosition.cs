using Microsoft.EntityFrameworkCore.Migrations;

namespace MeliChallenge.Data.Migrations
{
    public partial class addMessagePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MessagePositionX",
                table: "Messages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MessagePositionY",
                table: "Messages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessagePositionX",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessagePositionY",
                table: "Messages");
        }
    }
}
