using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForTec.Infraestruct.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_solicitantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_solicitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arbovirose = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SemanaInicio = table.Column<int>(type: "int", nullable: false),
                    SemanaFim = table.Column<int>(type: "int", nullable: false),
                    CodigoIbge = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SolicitanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatorios_tb_solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "tb_solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_SolicitanteId",
                table: "Relatorios",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_solicitantes_Cpf",
                table: "tb_solicitantes",
                column: "Cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "tb_solicitantes");
        }
    }
}
