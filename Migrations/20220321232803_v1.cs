using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bioskop",
                columns: table => new
                {
                    IdBioskopa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bioskop", x => x.IdBioskopa);
                });

            migrationBuilder.CreateTable(
                name: "Dani",
                columns: table => new
                {
                    IdDana = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dani", x => x.IdDana);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    IdFilma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Popust = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.IdFilma);
                });

            migrationBuilder.CreateTable(
                name: "BioskopDani",
                columns: table => new
                {
                    DaniBioskopIdBioskopa = table.Column<int>(type: "int", nullable: false),
                    DaniBioskopIdDana = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioskopDani", x => new { x.DaniBioskopIdBioskopa, x.DaniBioskopIdDana });
                    table.ForeignKey(
                        name: "FK_BioskopDani_Bioskop_DaniBioskopIdBioskopa",
                        column: x => x.DaniBioskopIdBioskopa,
                        principalTable: "Bioskop",
                        principalColumn: "IdBioskopa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BioskopDani_Dani_DaniBioskopIdDana",
                        column: x => x.DaniBioskopIdDana,
                        principalTable: "Dani",
                        principalColumn: "IdDana",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaniFilm",
                columns: table => new
                {
                    FilmDaniIdDana = table.Column<int>(type: "int", nullable: false),
                    FilmoviDaniIdFilma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaniFilm", x => new { x.FilmDaniIdDana, x.FilmoviDaniIdFilma });
                    table.ForeignKey(
                        name: "FK_DaniFilm_Dani_FilmDaniIdDana",
                        column: x => x.FilmDaniIdDana,
                        principalTable: "Dani",
                        principalColumn: "IdDana",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaniFilm_Film_FilmoviDaniIdFilma",
                        column: x => x.FilmoviDaniIdFilma,
                        principalTable: "Film",
                        principalColumn: "IdFilma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BioskopDani_DaniBioskopIdDana",
                table: "BioskopDani",
                column: "DaniBioskopIdDana");

            migrationBuilder.CreateIndex(
                name: "IX_DaniFilm_FilmoviDaniIdFilma",
                table: "DaniFilm",
                column: "FilmoviDaniIdFilma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BioskopDani");

            migrationBuilder.DropTable(
                name: "DaniFilm");

            migrationBuilder.DropTable(
                name: "Bioskop");

            migrationBuilder.DropTable(
                name: "Dani");

            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
