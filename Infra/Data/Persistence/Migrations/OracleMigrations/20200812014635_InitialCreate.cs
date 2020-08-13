using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Persistence.Migrations.OracleMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MARCACOES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCACOES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PESSOAS",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAS", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MARCACOES");

            migrationBuilder.DropTable(
                name: "PESSOAS");
        }
    }
}
