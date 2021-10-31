using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionPersonas.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    GrupoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    CantidadPersonas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.GrupoId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "TiposAportes",
                columns: table => new
                {
                    TipoAporteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Meta = table.Column<float>(type: "REAL", nullable: false),
                    Logrado = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAportes", x => x.TipoAporteID);
                });

            migrationBuilder.CreateTable(
                name: "GruposDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GrupoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Orden = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GruposDetalle_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "GrupoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    TotalAportado = table.Column<float>(type: "REAL", nullable: false),
                    RolId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Personas_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aportes",
                columns: table => new
                {
                    AporteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonaID = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: true),
                    Monto = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aportes", x => x.AporteID);
                    table.ForeignKey(
                        name: "FK_Aportes_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AportesDetalles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoAporteID = table.Column<int>(type: "INTEGER", nullable: false),
                    AporteID = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AportesDetalles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AportesDetalles_Aportes_AporteID",
                        column: x => x.AporteID,
                        principalTable: "Aportes",
                        principalColumn: "AporteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AportesDetalles_TiposAportes_TipoAporteID",
                        column: x => x.TipoAporteID,
                        principalTable: "TiposAportes",
                        principalColumn: "TipoAporteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aportes_PersonaID",
                table: "Aportes",
                column: "PersonaID");

            migrationBuilder.CreateIndex(
                name: "IX_AportesDetalles_AporteID",
                table: "AportesDetalles",
                column: "AporteID");

            migrationBuilder.CreateIndex(
                name: "IX_AportesDetalles_TipoAporteID",
                table: "AportesDetalles",
                column: "TipoAporteID");

            migrationBuilder.CreateIndex(
                name: "IX_GruposDetalle_GrupoId",
                table: "GruposDetalle",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_RolId",
                table: "Personas",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AportesDetalles");

            migrationBuilder.DropTable(
                name: "GruposDetalle");

            migrationBuilder.DropTable(
                name: "Aportes");

            migrationBuilder.DropTable(
                name: "TiposAportes");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
