using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brans",
                columns: table => new
                {
                    Brans_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brans_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brans", x => x.Brans_Id);
                });

            migrationBuilder.CreateTable(
                name: "ilis",
                columns: table => new
                {
                    il_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    il_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilis", x => x.il_Id);
                });

            migrationBuilder.CreateTable(
                name: "Okuls",
                columns: table => new
                {
                    Okul_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkulAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiNo = table.Column<int>(type: "int", nullable: false),
                    ilce_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okuls", x => x.Okul_Id);
                });

            migrationBuilder.CreateTable(
                name: "ilcesis",
                columns: table => new
                {
                    ilce_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ilce_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    il_Id = table.Column<int>(type: "int", nullable: false),
                    iliil_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilcesis", x => x.ilce_Id);
                    table.ForeignKey(
                        name: "FK_ilcesis_ilis_iliil_Id",
                        column: x => x.iliil_Id,
                        principalTable: "ilis",
                        principalColumn: "il_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ilcesis_iliil_Id",
                table: "ilcesis",
                column: "iliil_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brans");

            migrationBuilder.DropTable(
                name: "ilcesis");

            migrationBuilder.DropTable(
                name: "Okuls");

            migrationBuilder.DropTable(
                name: "ilis");
        }
    }
}
