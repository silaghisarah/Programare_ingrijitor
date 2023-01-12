using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programare_ingrijitor.Migrations
{
    public partial class AllInOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireCategorie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varsta = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ingrijitor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrijitor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireZona = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire_Serviciu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IngrijitorID = table.Column<int>(type: "int", nullable: true),
                    Cost_consultatie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data_Programare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZonaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Serviciu_Ingrijitor_IngrijitorID",
                        column: x => x.IngrijitorID,
                        principalTable: "Ingrijitor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviciu_Zona_ZonaID",
                        column: x => x.ZonaID,
                        principalTable: "Zona",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    IngrijitorID = table.Column<int>(type: "int", nullable: true),
                    ServiciuID = table.Column<int>(type: "int", nullable: true),
                    DataProgramare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZonaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programare_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Ingrijitor_IngrijitorID",
                        column: x => x.IngrijitorID,
                        principalTable: "Ingrijitor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Zona_ZonaID",
                        column: x => x.ZonaID,
                        principalTable: "Zona",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ServiciuCategorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiciuID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciuCategorie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiciuCategorie_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciuCategorie_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ClientID",
                table: "Programare",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_IngrijitorID",
                table: "Programare",
                column: "IngrijitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ServiciuID",
                table: "Programare",
                column: "ServiciuID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ZonaID",
                table: "Programare",
                column: "ZonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_IngrijitorID",
                table: "Serviciu",
                column: "IngrijitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_ZonaID",
                table: "Serviciu",
                column: "ZonaID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciuCategorie_CategorieID",
                table: "ServiciuCategorie",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciuCategorie_ServiciuID",
                table: "ServiciuCategorie",
                column: "ServiciuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");

            migrationBuilder.DropTable(
                name: "ServiciuCategorie");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Serviciu");

            migrationBuilder.DropTable(
                name: "Ingrijitor");

            migrationBuilder.DropTable(
                name: "Zona");
        }
    }
}
