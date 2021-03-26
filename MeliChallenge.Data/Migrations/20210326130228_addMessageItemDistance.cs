using Microsoft.EntityFrameworkCore.Migrations;

namespace MeliChallenge.Data.Migrations
{
    public partial class addMessageItemDistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Distance",
                table: "MessageItems",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "MessageItems");
        }
    }
}
