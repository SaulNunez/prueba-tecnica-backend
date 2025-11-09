using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prueba_tecnica_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperadorId = table.Column<int>(type: "int", nullable: false),
                    RutaId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viajes_Operadores_OperadorId",
                        column: x => x.OperadorId,
                        principalTable: "Operadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viajes_Rutas_RutaId",
                        column: x => x.RutaId,
                        principalTable: "Rutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Operadores",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ramón López" },
                    { 2, "Saúl Núñez" },
                    { 3, "Mario Perez" },
                    { 4, "Pedro Ródriguez" }
                });

            migrationBuilder.InsertData(
                table: "Rutas",
                columns: new[] { "Id", "Destino", "Origen" },
                values: new object[,]
                {
                    { 1, "Delicias", "Chihuahua" },
                    { 2, "Chihuahua", "Juárez" },
                    { 3, "Juárez", "Delicias" },
                    { 4, "Chihuahua", "Delicias" },
                    { 5, "Juárez", "Chihuahua" },
                    { 6, "Delicias", "Juárez" },
                    { 7, "Ciudad de México", "Chihuahua" },
                    { 8, "Chihuahua", "Ciudad de México" },
                    { 9, "Ciudad de México", "Juárez" },
                    { 10, "Juárez", "Ciudad de México" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_OperadorId",
                table: "Viajes",
                column: "OperadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_RutaId",
                table: "Viajes",
                column: "RutaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "Operadores");

            migrationBuilder.DropTable(
                name: "Rutas");
        }
    }
}
