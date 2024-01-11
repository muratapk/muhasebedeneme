using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    public partial class mig44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brans",
                columns: table => new
                {
                    Brans_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brans_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brans", x => x.Brans_Id);
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
                    ilisil_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilcesis", x => x.ilce_Id);
                    table.ForeignKey(
                        name: "FK_ilcesis_ilis_ilisil_Id",
                        column: x => x.ilisil_Id,
                        principalTable: "ilis",
                        principalColumn: "il_Id");
                });

            migrationBuilder.CreateTable(
                name: "Maliyets",
                columns: table => new
                {
                    Maliyet_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isin_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isin_Adedi = table.Column<int>(type: "int", nullable: false),
                    Tutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pesin_Gelir = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    kar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idari_pay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    shcek = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iscilik = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    malzeme = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ogretmen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ogrenci = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Okul_Id = table.Column<int>(type: "int", nullable: false),
                    Okul_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maliyets", x => x.Maliyet_Id);
                    table.ForeignKey(
                        name: "FK_Maliyets_Okuls_Okul_Id1",
                        column: x => x.Okul_Id1,
                        principalTable: "Okuls",
                        principalColumn: "Okul_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ilcesis_ilisil_Id",
                table: "ilcesis",
                column: "ilisil_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Maliyets_Okul_Id1",
                table: "Maliyets",
                column: "Okul_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brans");

            migrationBuilder.DropTable(
                name: "ilcesis");

            migrationBuilder.DropTable(
                name: "Maliyets");

            migrationBuilder.DropTable(
                name: "ilis");

            migrationBuilder.DropTable(
                name: "Okuls");
        }
    }
}
