using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace p1_Ap1_RamonUreña.Migrations
{
    /// <inheritdoc />
    public partial class Existencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntradasHuacales",
                columns: table => new
                {
                    IdEntrada = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NombreCliente = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Importe = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacales", x => x.IdEntrada);
                });

            migrationBuilder.CreateTable(
                name: "TipoHuacales",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoColor = table.Column<string>(type: "TEXT", nullable: true),
                    TipoTamano = table.Column<string>(type: "TEXT", nullable: true),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHuacales", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "DetallesHuacales",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TiposId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    IdEntrada = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesHuacales", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_DetallesHuacales_EntradasHuacales_IdEntrada",
                        column: x => x.IdEntrada,
                        principalTable: "EntradasHuacales",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoHuacales",
                columns: new[] { "TipoId", "Existencia", "TipoColor", "TipoTamano" },
                values: new object[,]
                {
                    { 1, 0, "Verde", "Grande" },
                    { 2, 0, "Rojo", "Grande" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesHuacales_IdEntrada",
                table: "DetallesHuacales",
                column: "IdEntrada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesHuacales");

            migrationBuilder.DropTable(
                name: "TipoHuacales");

            migrationBuilder.DropTable(
                name: "EntradasHuacales");
        }
    }
}
