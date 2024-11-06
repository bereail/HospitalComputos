using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__2DCCF9A2EBB6A747", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "Toner",
                columns: table => new
                {
                    IdToner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Toner__D6F13E8168B03651", x => x.IdToner);
                });

            migrationBuilder.CreateTable(
                name: "Computadoras",
                columns: table => new
                {
                    IdComputadora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Computad__1102CC84094D511E", x => x.IdComputadora);
                    table.ForeignKey(
                        name: "FK__Computado__IdSer__693CA210",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EntregaToner",
                columns: table => new
                {
                    IdEntregaToner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdToner = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdServicio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EntregaT__D2D3856D62C9E55F", x => x.IdEntregaToner);
                    table.ForeignKey(
                        name: "FK__EntregaTo__IdSer__6EF57B66",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio");
                    table.ForeignKey(
                        name: "FK__EntregaTo__IdTon__6E01572D",
                        column: x => x.IdToner,
                        principalTable: "Toner",
                        principalColumn: "IdToner");
                });

            migrationBuilder.CreateTable(
                name: "Impresoras",
                columns: table => new
                {
                    IdImpresora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreImpresora = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdComputadora = table.Column<int>(type: "int", nullable: true),
                    IdToner = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Impresor__627CBB0C44EB7FF2", x => x.IdImpresora);
                    table.ForeignKey(
                        name: "FK__Impresora__IdCom__71D1E811",
                        column: x => x.IdComputadora,
                        principalTable: "Computadoras",
                        principalColumn: "IdComputadora",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Impresora__IdTon__72C60C4A",
                        column: x => x.IdToner,
                        principalTable: "Toner",
                        principalColumn: "IdToner");
                });

            migrationBuilder.CreateTable(
                name: "Reparaciones",
                columns: table => new
                {
                    IdReparacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComputadora = table.Column<int>(type: "int", nullable: true),
                    Descripción = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reparaci__DCF37F00CECD80DF", x => x.IdReparacion);
                    table.ForeignKey(
                        name: "FK__Reparacio__IdCom__75A278F5",
                        column: x => x.IdComputadora,
                        principalTable: "Computadoras",
                        principalColumn: "IdComputadora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computadoras_IdServicio",
                table: "Computadoras",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_EntregaToner_IdServicio",
                table: "EntregaToner",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_EntregaToner_IdToner",
                table: "EntregaToner",
                column: "IdToner");

            migrationBuilder.CreateIndex(
                name: "IX_Impresoras_IdComputadora",
                table: "Impresoras",
                column: "IdComputadora");

            migrationBuilder.CreateIndex(
                name: "IX_Impresoras_IdToner",
                table: "Impresoras",
                column: "IdToner");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdComputadora",
                table: "Reparaciones",
                column: "IdComputadora");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntregaToner");

            migrationBuilder.DropTable(
                name: "Impresoras");

            migrationBuilder.DropTable(
                name: "Reparaciones");

            migrationBuilder.DropTable(
                name: "Toner");

            migrationBuilder.DropTable(
                name: "Computadoras");

            migrationBuilder.DropTable(
                name: "Servicios");
        }
    }
}
