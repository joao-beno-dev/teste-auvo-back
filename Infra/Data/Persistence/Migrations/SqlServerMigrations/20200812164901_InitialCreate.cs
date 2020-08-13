using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "MARCACOES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    PessoaId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCACOES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MARCACOES_PESSOAS_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "PESSOAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PESSOAS",
                column: "Id",
                values: new object[]
                {
                    "João",
                    "Pedro",
                    "Vanessa",
                    "Karla",
                    "Maxwell",
                    "Maxine",
                    "Maxmiliano",
                    "Mario"
                });

            migrationBuilder.InsertData(
                table: "MARCACOES",
                columns: new[] { "Id", "DataHora", "Descricao", "PessoaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), "Inicio Dia 1", "João" },
                    { 2, new DateTime(2020, 8, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fim Dia 1 (Inicio projeto e modelos)", "João" },
                    { 3, new DateTime(2020, 8, 9, 20, 0, 0, 0, DateTimeKind.Unspecified), "Inicio Dia 2", "João" },
                    { 4, new DateTime(2020, 8, 9, 22, 0, 0, 0, DateTimeKind.Unspecified), "Fim Dia 2 (modelos e persistencia)", "João" },
                    { 5, new DateTime(2020, 8, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), "Inicio Dia 3", "João" },
                    { 6, new DateTime(2020, 8, 10, 22, 0, 0, 0, DateTimeKind.Unspecified), "Fim Dia 3 (Persistencia, migrations e dbs)", "João" },
                    { 7, new DateTime(2020, 8, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), "Inicio Dia 4", "João" },
                    { 8, new DateTime(2020, 8, 11, 22, 0, 0, 0, DateTimeKind.Unspecified), "Fim Dia 4 (Seeds, Rotas e Testes)", "João" },
                    { 9, new DateTime(2020, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "Inicio Dia 5", "João" },
                    { 10, new DateTime(2020, 8, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), "Fim Dia 5 (Bug Fixes, Remoção testes e Pipeline CD não implementados, Commit)", "João" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MARCACOES_PessoaId",
                table: "MARCACOES",
                column: "PessoaId");
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
