using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csegurancacap7.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Action = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TeamId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TeamName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Availability = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ZoneId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ActionTimestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_OCORRENCIA",
                columns: table => new
                {
                    ID_OCORRENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_SO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DS_STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ID_ZONE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_TEAM = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DT_SERVICE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_END = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DS_RESOLVIDO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DS_OBSERVACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OCORRENCIA", x => x.ID_OCORRENCIA);
                });

            migrationBuilder.CreateTable(
                name: "T_TEAM",
                columns: table => new
                {
                    ID_TEAM = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_TEAM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NM_QTD = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DS_ESPECIALIDADE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NM_DISPONIBILIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_ZONE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TEAM", x => x.ID_TEAM);
                });

            migrationBuilder.CreateTable(
                name: "T_USER",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_USER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_EMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_SENHA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_TELEFONE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "T_ZONE",
                columns: table => new
                {
                    ID_ZONE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_ZONE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_CATEGORIA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ZONE", x => x.ID_ZONE);
                });

            migrationBuilder.CreateTable(
                name: "T_SO",
                columns: table => new
                {
                    ID_SO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_USER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DS_TIPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ID_ZONE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DT_FATO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_HORA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SO", x => x.ID_SO);
                    table.ForeignKey(
                        name: "FK_T_SO_T_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "T_USER",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_SO_T_ZONE_ID_ZONE",
                        column: x => x.ID_ZONE,
                        principalTable: "T_ZONE",
                        principalColumn: "ID_ZONE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_SO_ID_USER",
                table: "T_SO",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_T_SO_ID_ZONE",
                table: "T_SO",
                column: "ID_ZONE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "T_OCORRENCIA");

            migrationBuilder.DropTable(
                name: "T_SO");

            migrationBuilder.DropTable(
                name: "T_TEAM");

            migrationBuilder.DropTable(
                name: "T_USER");

            migrationBuilder.DropTable(
                name: "T_ZONE");
        }
    }
}
