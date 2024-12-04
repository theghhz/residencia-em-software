using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgendaConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoraInicial = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HoraFinal = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CPF = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Pacientes_CPF",
                        column: x => x.CPF,
                        principalTable: "Pacientes",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_CPF",
                table: "Agendamentos",
                column: "CPF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
