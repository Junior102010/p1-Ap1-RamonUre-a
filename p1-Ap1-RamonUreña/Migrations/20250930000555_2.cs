using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace p1_Ap1_RamonUreña.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registro",
                table: "Registro");

            migrationBuilder.RenameTable(
                name: "Registro",
                newName: "EntradasHuacales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntradasHuacales",
                table: "EntradasHuacales",
                column: "IdEntrada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EntradasHuacales",
                table: "EntradasHuacales");

            migrationBuilder.RenameTable(
                name: "EntradasHuacales",
                newName: "Registro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registro",
                table: "Registro",
                column: "IdEntrada");
        }
    }
}
