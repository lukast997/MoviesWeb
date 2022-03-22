using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Popust",
                table: "Film");

            migrationBuilder.AddColumn<string>(
                name: "Projekcija",
                table: "Film",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Projekcija",
                table: "Film");

            migrationBuilder.AddColumn<int>(
                name: "Popust",
                table: "Film",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
