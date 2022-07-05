using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt.Migratiopns
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dane");

            migrationBuilder.CreateTable(
                name: "IMGWDaneSynoptyczne",
                schema: "dane",
                columns: table => new
                {
                    id_stacji = table.Column<int>(type: "int", nullable: false),
                    stacja = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    suma_opadu = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IMGWDane__46736E00A5A8752C", x => x.id_stacji);
                });

            migrationBuilder.CreateTable(
                name: "ObszaryZalewowe",
                schema: "dane",
                columns: table => new
                {
                    NazwaRzeki = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Miasto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Miejscowosc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ObszaryZ__D7B57E02222793B7", x => x.NazwaRzeki);
                });

            migrationBuilder.CreateTable(
                name: "PomiarRzeki",
                schema: "dane",
                columns: table => new
                {
                    NazwaRzeki = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PoziomWody = table.Column<double>(type: "float", nullable: false),
                    StandardowyPoziom = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PomiarRz__D7B57E020A039002", x => x.NazwaRzeki);
                });

            migrationBuilder.CreateTable(
                name: "PowodzieHistoryczne",
                schema: "dane",
                columns: table => new
                {
                    Miejscowosc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Miasto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Powodzie__A551532136C135D3", x => x.Miejscowosc);
                });

            migrationBuilder.CreateTable(
                name: "PrognozaPogody",
                schema: "dane",
                columns: table => new
                {
                    Miasto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Deszcz = table.Column<bool>(type: "bit", nullable: false),
                    IloscOpadow = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prognoza__5B08C15F6681C165", x => x.Miasto);
                });

            migrationBuilder.CreateTable(
                name: "DataPomiaruZStacji",
                schema: "dane",
                columns: table => new
                {
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    id_stacji = table.Column<int>(type: "int", nullable: false),
                    Dzień = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Miesiąc = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Rok = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DataPomi__77387D0AD5FE7994", x => x.Data);
                    table.ForeignKey(
                        name: "id_stacji",
                        column: x => x.id_stacji,
                        principalSchema: "dane",
                        principalTable: "IMGWDaneSynoptyczne",
                        principalColumn: "id_stacji",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataPomiaru",
                schema: "dane",
                columns: table => new
                {
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    NazwaRzeki = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dzień = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Miesiąc = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Rok = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DataPomi__77387D0A9DE95860", x => x.Data);
                    table.ForeignKey(
                        name: "NazwaRzekiPomiaru",
                        column: x => x.NazwaRzeki,
                        principalSchema: "dane",
                        principalTable: "PomiarRzeki",
                        principalColumn: "NazwaRzeki",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObszarZagrozony",
                schema: "dane",
                columns: table => new
                {
                    Miejscowosc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Miasto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NazwaRzeki = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ObszarZa__726D9DB7951D029F", x => x.Miejscowosc);
                    table.ForeignKey(
                        name: "NazwaRzeki",
                        column: x => x.NazwaRzeki,
                        principalSchema: "dane",
                        principalTable: "PomiarRzeki",
                        principalColumn: "NazwaRzeki",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataPowodziHis",
                schema: "dane",
                columns: table => new
                {
                    DataPowodzi = table.Column<DateTime>(type: "date", nullable: false),
                    Miejscowość = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dzień = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Miesiąc = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Rok = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DataPowo__E93B82BA9832E658", x => x.DataPowodzi);
                    table.ForeignKey(
                        name: "Miejscowość",
                        column: x => x.Miejscowość,
                        principalSchema: "dane",
                        principalTable: "PowodzieHistoryczne",
                        principalColumn: "Miejscowosc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataPrognozy",
                schema: "dane",
                columns: table => new
                {
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    Miasto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dzień = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Miesiąc = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Rok = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DataProg__77387D0A5BABE65A", x => x.Data);
                    table.ForeignKey(
                        name: "Miasto",
                        column: x => x.Miasto,
                        principalSchema: "dane",
                        principalTable: "PrognozaPogody",
                        principalColumn: "Miasto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OstrzeganieInstytucji",
                schema: "dane",
                columns: table => new
                {
                    StanZagrozenia = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MiastoOrganizacji = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MiejscowoscOrganizacji = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MiejscowoscZagrozona = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NazwaSluzby = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "Miejscowosc",
                        column: x => x.MiejscowoscZagrozona,
                        principalSchema: "dane",
                        principalTable: "ObszarZagrozony",
                        principalColumn: "Miejscowosc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowiadomienieSMS",
                schema: "dane",
                columns: table => new
                {
                    NumerTelefonu = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    StanZagrozenia = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Miasto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Miejscowosc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Powiadom__6C70F0C2239BCF5F", x => x.NumerTelefonu);
                    table.ForeignKey(
                        name: "Miejscowosc2",
                        column: x => x.Miejscowosc,
                        principalSchema: "dane",
                        principalTable: "ObszarZagrozony",
                        principalColumn: "Miejscowosc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RodzajSłużbyRatunkowej",
                schema: "dane",
                columns: table => new
                {
                    Miejscowość = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Pog_ratunkowe = table.Column<bool>(type: "bit", nullable: false),
                    Straż_pożarna = table.Column<bool>(type: "bit", nullable: false),
                    Policja = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "Miejscowosce",
                        column: x => x.Miejscowość,
                        principalSchema: "dane",
                        principalTable: "ObszarZagrozony",
                        principalColumn: "Miejscowosc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPomiaru_NazwaRzeki",
                schema: "dane",
                table: "DataPomiaru",
                column: "NazwaRzeki");

            migrationBuilder.CreateIndex(
                name: "IX_DataPomiaruZStacji_id_stacji",
                schema: "dane",
                table: "DataPomiaruZStacji",
                column: "id_stacji");

            migrationBuilder.CreateIndex(
                name: "IX_DataPowodziHis_Miejscowość",
                schema: "dane",
                table: "DataPowodziHis",
                column: "Miejscowość");

            migrationBuilder.CreateIndex(
                name: "IX_DataPrognozy_Miasto",
                schema: "dane",
                table: "DataPrognozy",
                column: "Miasto");

            migrationBuilder.CreateIndex(
                name: "IX_ObszarZagrozony_NazwaRzeki",
                schema: "dane",
                table: "ObszarZagrozony",
                column: "NazwaRzeki");

            migrationBuilder.CreateIndex(
                name: "IX_OstrzeganieInstytucji_MiejscowoscZagrozona",
                schema: "dane",
                table: "OstrzeganieInstytucji",
                column: "MiejscowoscZagrozona");

            migrationBuilder.CreateIndex(
                name: "IX_PowiadomienieSMS_Miejscowosc",
                schema: "dane",
                table: "PowiadomienieSMS",
                column: "Miejscowosc");

            migrationBuilder.CreateIndex(
                name: "IX_RodzajSłużbyRatunkowej_Miejscowość",
                schema: "dane",
                table: "RodzajSłużbyRatunkowej",
                column: "Miejscowość");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPomiaru",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "DataPomiaruZStacji",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "DataPowodziHis",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "DataPrognozy",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "ObszaryZalewowe",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "OstrzeganieInstytucji",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "PowiadomienieSMS",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "RodzajSłużbyRatunkowej",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "IMGWDaneSynoptyczne",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "PowodzieHistoryczne",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "PrognozaPogody",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "ObszarZagrozony",
                schema: "dane");

            migrationBuilder.DropTable(
                name: "PomiarRzeki",
                schema: "dane");
        }
    }
}
