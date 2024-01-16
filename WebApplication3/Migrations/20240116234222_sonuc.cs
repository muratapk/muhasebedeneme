using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    public partial class sonuc : Migration
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
                name: "Mils",
                columns: table => new
                {
                    MilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mils", x => x.MilId);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<int>(type: "int", nullable: true),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BransId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelId);
                });

            migrationBuilder.CreateTable(
                name: "Milces",
                columns: table => new
                {
                    MilceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milces", x => x.MilceId);
                    table.ForeignKey(
                        name: "FK_Milces_Mils_MilId",
                        column: x => x.MilId,
                        principalTable: "Mils",
                        principalColumn: "MilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Okuls",
                columns: table => new
                {
                    OkulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkulAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiNo = table.Column<int>(type: "int", nullable: false),
                    MilceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okuls", x => x.OkulId);
                    table.ForeignKey(
                        name: "FK_Okuls_Milces_MilceId",
                        column: x => x.MilceId,
                        principalTable: "Milces",
                        principalColumn: "MilceId");
                });

            migrationBuilder.CreateTable(
                name: "Maliyets",
                columns: table => new
                {
                    MaliyetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isin_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isin_Adedi = table.Column<int>(type: "int", nullable: false),
                    Tutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pesin_Gelir = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Idari_pay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shcek = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iscilik = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ogretmen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ogrenci = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OkulId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maliyets", x => x.MaliyetId);
                    table.ForeignKey(
                        name: "FK_Maliyets_Okuls_OkulId",
                        column: x => x.OkulId,
                        principalTable: "Okuls",
                        principalColumn: "OkulId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hesaps",
                columns: table => new
                {
                    Hesap_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maliyet_Id = table.Column<int>(type: "int", nullable: false),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaps", x => x.Hesap_Id);
                    table.ForeignKey(
                        name: "FK_Hesaps_Maliyets_Maliyet_Id",
                        column: x => x.Maliyet_Id,
                        principalTable: "Maliyets",
                        principalColumn: "MaliyetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hesaps_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hesaps_Maliyet_Id",
                table: "Hesaps",
                column: "Maliyet_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hesaps_Personel_Id",
                table: "Hesaps",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Maliyets_OkulId",
                table: "Maliyets",
                column: "OkulId");

            migrationBuilder.CreateIndex(
                name: "IX_Milces_MilId",
                table: "Milces",
                column: "MilId");

            migrationBuilder.CreateIndex(
                name: "IX_Okuls_MilceId",
                table: "Okuls",
                column: "MilceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brans");

            migrationBuilder.DropTable(
                name: "Hesaps");

            migrationBuilder.DropTable(
                name: "Maliyets");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Okuls");

            migrationBuilder.DropTable(
                name: "Milces");

            migrationBuilder.DropTable(
                name: "Mils");
        }
    }
}
