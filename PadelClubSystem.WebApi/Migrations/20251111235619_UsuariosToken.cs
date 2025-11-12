using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PadelClubSystem.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UsuariosToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Socios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Socios");

            migrationBuilder.RenameColumn(
                name: "FechaAlta",
                table: "Socios",
                newName: "FechaNacimiento");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "Socios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "Socios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TelefonoMovil",
                table: "Socios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Anios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CaducaEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMes = table.Column<int>(type: "int", nullable: false),
                    IdAnio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuotas_Anios_IdAnio",
                        column: x => x.IdAnio,
                        principalTable: "Anios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cuotas_Meses_IdMes",
                        column: x => x.IdMes,
                        principalTable: "Meses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoutasPorSocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    IdCouta = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Recargo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnioId = table.Column<int>(type: "int", nullable: true),
                    MesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoutasPorSocios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoutasPorSocios_Anios_AnioId",
                        column: x => x.AnioId,
                        principalTable: "Anios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoutasPorSocios_Cuotas_IdCouta",
                        column: x => x.IdCouta,
                        principalTable: "Cuotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CoutasPorSocios_Meses_MesId",
                        column: x => x.MesId,
                        principalTable: "Meses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoutasPorSocios_Socios_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoutasPorSocios_AnioId",
                table: "CoutasPorSocios",
                column: "AnioId");

            migrationBuilder.CreateIndex(
                name: "IX_CoutasPorSocios_IdCouta",
                table: "CoutasPorSocios",
                column: "IdCouta");

            migrationBuilder.CreateIndex(
                name: "IX_CoutasPorSocios_IdSocio",
                table: "CoutasPorSocios",
                column: "IdSocio");

            migrationBuilder.CreateIndex(
                name: "IX_CoutasPorSocios_MesId",
                table: "CoutasPorSocios",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_IdAnio",
                table: "Cuotas",
                column: "IdAnio");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_IdMes",
                table: "Cuotas",
                column: "IdMes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoutasPorSocios");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "Anios");

            migrationBuilder.DropTable(
                name: "Meses");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "Socios");

            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "Socios");

            migrationBuilder.DropColumn(
                name: "TelefonoMovil",
                table: "Socios");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Socios",
                newName: "FechaAlta");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Socios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Socios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
