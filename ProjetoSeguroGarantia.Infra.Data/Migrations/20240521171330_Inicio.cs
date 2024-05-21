using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSeguroGarantia.Infra.Data.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_SeguraGarantia",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Finalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beneficiarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiposDeProcessos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vantagens = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funcionamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exigencias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SeguraGarantia", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_SeguraGarantia");
        }
    }
}
