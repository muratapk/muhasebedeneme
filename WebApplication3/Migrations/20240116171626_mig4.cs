using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    public partial class mig4 : Migration
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
                name: "Personels",
                columns: table => new
                {
                    Personel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<int>(type: "int", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brans_Id = table.Column<int>(type: "int", nullable: false),
                    Brans_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.Personel_Id);
                    table.ForeignKey(
                        name: "FK_Personels_Brans_Brans_Id1",
                        column: x => x.Brans_Id1,
                        principalTable: "Brans",
                        principalColumn: "Brans_Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Hesaps",
                columns: table => new
                {
                    Hesap_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maliyet_Id = table.Column<int>(type: "int", nullable: false),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Personel_Id1 = table.Column<int>(type: "int", nullable: false),
                    Maliyet_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaps", x => x.Hesap_Id);
                    table.ForeignKey(
                        name: "FK_Hesaps_Maliyets_Maliyet_Id1",
                        column: x => x.Maliyet_Id1,
                        principalTable: "Maliyets",
                        principalColumn: "Maliyet_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hesaps_Personels_Personel_Id1",
                        column: x => x.Personel_Id1,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hesaps_Maliyet_Id1",
                table: "Hesaps",
                column: "Maliyet_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Hesaps_Personel_Id1",
                table: "Hesaps",
                column: "Personel_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_ilcesis_ilisil_Id",
                table: "ilcesis",
                column: "ilisil_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Maliyets_Okul_Id1",
                table: "Maliyets",
                column: "Okul_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_Brans_Id1",
                table: "Personels",
                column: "Brans_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hesaps");

            migrationBuilder.DropTable(
                name: "ilcesis");

            migrationBuilder.DropTable(
                name: "Maliyets");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "ilis");

            migrationBuilder.DropTable(
                name: "Okuls");

            migrationBuilder.DropTable(
                name: "Brans");
        }
    }
}
