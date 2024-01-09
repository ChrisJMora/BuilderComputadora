using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuilderAPI.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computadoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemoriaRam = table.Column<int>(type: "int", nullable: false),
                    Almacenamiento = table.Column<int>(type: "int", nullable: false),
                    NucleosProcesador = table.Column<int>(type: "int", nullable: false),
                    PuertosUsb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computadoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputadoraComponentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComputadora = table.Column<int>(type: "int", nullable: false),
                    IdComponente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputadoraComponentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputadoraComponentes_Componentes_IdComponente",
                        column: x => x.IdComponente,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputadoraComponentes_Computadoras_IdComputadora",
                        column: x => x.IdComputadora,
                        principalTable: "Computadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Componentes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Tarjeta de video" },
                    { 2, "Gabinete" },
                    { 3, "Monitor" },
                    { 4, "Teclado" },
                    { 5, "Mouse" },
                    { 6, "Parlantes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputadoraComponentes_IdComponente",
                table: "ComputadoraComponentes",
                column: "IdComponente");

            migrationBuilder.CreateIndex(
                name: "IX_ComputadoraComponentes_IdComputadora",
                table: "ComputadoraComponentes",
                column: "IdComputadora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputadoraComponentes");

            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Computadoras");
        }
    }
}
