using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UsuariosApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_CLIENTE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF_CNPJ = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LOGRADOURO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    BAIRRO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CIDADE = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CEP = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_SISTEMA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODIGO = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    URL = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SISTEMA", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SENHA = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CLIENTE_ID = table.Column<int>(type: "int", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_USUARIO_TB_CLIENTE_CLIENTE_ID",
                        column: x => x.CLIENTE_ID,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_API",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    URI = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SISTEMA_ID = table.Column<int>(type: "int", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_API", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_API_TB_SISTEMA_SISTEMA_ID",
                        column: x => x.SISTEMA_ID,
                        principalTable: "TB_SISTEMA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_CLIENTE_SISTEMA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CLIENTE_ID = table.Column<int>(type: "int", nullable: false),
                    SISTEMA_ID = table.Column<int>(type: "int", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE_SISTEMA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CLIENTE_SISTEMA_TB_CLIENTE_CLIENTE_ID",
                        column: x => x.CLIENTE_ID,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_CLIENTE_SISTEMA_TB_SISTEMA_SISTEMA_ID",
                        column: x => x.SISTEMA_ID,
                        principalTable: "TB_SISTEMA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PERFIL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SISTEMA_ID = table.Column<int>(type: "int", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_PERFIL_TB_SISTEMA_SISTEMA_ID",
                        column: x => x.SISTEMA_ID,
                        principalTable: "TB_SISTEMA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PERFIL_API",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PERFIL_ID = table.Column<int>(type: "int", nullable: false),
                    API_ID = table.Column<int>(type: "int", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIL_API", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_PERFIL_API_TB_API_API_ID",
                        column: x => x.API_ID,
                        principalTable: "TB_API",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_PERFIL_API_TB_PERFIL_PERFIL_ID",
                        column: x => x.PERFIL_ID,
                        principalTable: "TB_PERFIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_USUARIO_PERFIL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USUARIO_ID = table.Column<int>(type: "int", nullable: false),
                    CLIENTE_SISTEMA_ID = table.Column<int>(type: "int", nullable: false),
                    PERFIL_ID = table.Column<int>(type: "int", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO_PERFIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_USUARIO_PERFIL_TB_CLIENTE_SISTEMA_CLIENTE_SISTEMA_ID",
                        column: x => x.CLIENTE_SISTEMA_ID,
                        principalTable: "TB_CLIENTE_SISTEMA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_USUARIO_PERFIL_TB_PERFIL_PERFIL_ID",
                        column: x => x.PERFIL_ID,
                        principalTable: "TB_PERFIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_USUARIO_PERFIL_TB_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TB_CLIENTE",
                columns: new[] { "ID", "ATIVO", "BAIRRO", "CEP", "CIDADE", "CPF_CNPJ", "DATA_ALTERACAO", "DATA_INCLUSAO", "LOGRADOURO", "NOME", "NUMERO", "UF" },
                values: new object[] { 1, true, "Centro", "20031140", "Rio de Janeiro", "26263267000165", new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), "Rua México", "Facto Soluções em TI", 31, "RJ" });

            migrationBuilder.InsertData(
                table: "TB_SISTEMA",
                columns: new[] { "ID", "ATIVO", "CODIGO", "DATA_ALTERACAO", "DATA_INCLUSAO", "NOME", "URL" },
                values: new object[] { 1, true, "CA", new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), "Central Admin", "http://localhost:5232/" });

            migrationBuilder.InsertData(
                table: "TB_API",
                columns: new[] { "ID", "ATIVO", "DATA_ALTERACAO", "DATA_INCLUSAO", "NOME", "SISTEMA_ID", "URI" },
                values: new object[] { 1, true, new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), "Criação de Usuário", 1, "api/usuarios/criar" });

            migrationBuilder.InsertData(
                table: "TB_CLIENTE_SISTEMA",
                columns: new[] { "ID", "ATIVO", "CLIENTE_ID", "DATA_ALTERACAO", "DATA_INCLUSAO", "SISTEMA_ID" },
                values: new object[] { 1, true, 1, new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), 1 });

            migrationBuilder.InsertData(
                table: "TB_PERFIL",
                columns: new[] { "ID", "ATIVO", "DATA_ALTERACAO", "DATA_INCLUSAO", "NOME", "SISTEMA_ID" },
                values: new object[] { 1, true, new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), "ADMINISTRADOR", 1 });

            migrationBuilder.InsertData(
                table: "TB_USUARIO",
                columns: new[] { "ID", "ATIVO", "CLIENTE_ID", "DATA_ALTERACAO", "DATA_INCLUSAO", "EMAIL", "NOME", "SENHA" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), "factoti@factoti.com.br", "Facto Soluções", "82a2c0a772363847406da82a26e5f94cda0d4e54b9c1edde375c63610bfe8386" },
                    { 2, true, 1, new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), "edmarfonseca12@gmail.com", "Edmar Fonseca", "e61fef737df8527480b6f25954acd71e17dbd0175bc7b377174f0614274b0535" }
                });

            migrationBuilder.InsertData(
                table: "TB_PERFIL_API",
                columns: new[] { "ID", "API_ID", "ATIVO", "DATA_ALTERACAO", "DATA_INCLUSAO", "PERFIL_ID" },
                values: new object[] { 1, 1, true, new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), 1 });

            migrationBuilder.InsertData(
                table: "TB_USUARIO_PERFIL",
                columns: new[] { "ID", "ATIVO", "CLIENTE_SISTEMA_ID", "DATA_ALTERACAO", "DATA_INCLUSAO", "PERFIL_ID", "USUARIO_ID" },
                values: new object[] { 1, true, 1, new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_API_SISTEMA_ID",
                table: "TB_API",
                column: "SISTEMA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_API_URI",
                table: "TB_API",
                column: "URI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTE_CPF_CNPJ",
                table: "TB_CLIENTE",
                column: "CPF_CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTE_SISTEMA_CLIENTE_ID_SISTEMA_ID",
                table: "TB_CLIENTE_SISTEMA",
                columns: new[] { "CLIENTE_ID", "SISTEMA_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTE_SISTEMA_SISTEMA_ID",
                table: "TB_CLIENTE_SISTEMA",
                column: "SISTEMA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_NOME_SISTEMA_ID",
                table: "TB_PERFIL",
                columns: new[] { "NOME", "SISTEMA_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_SISTEMA_ID",
                table: "TB_PERFIL",
                column: "SISTEMA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_API_API_ID",
                table: "TB_PERFIL_API",
                column: "API_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_API_PERFIL_ID_API_ID",
                table: "TB_PERFIL_API",
                columns: new[] { "PERFIL_ID", "API_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_SISTEMA_URL",
                table: "TB_SISTEMA",
                column: "URL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_CLIENTE_ID",
                table: "TB_USUARIO",
                column: "CLIENTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_EMAIL",
                table: "TB_USUARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_PERFIL_CLIENTE_SISTEMA_ID",
                table: "TB_USUARIO_PERFIL",
                column: "CLIENTE_SISTEMA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_PERFIL_PERFIL_ID",
                table: "TB_USUARIO_PERFIL",
                column: "PERFIL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_PERFIL_USUARIO_ID_CLIENTE_SISTEMA_ID",
                table: "TB_USUARIO_PERFIL",
                columns: new[] { "USUARIO_ID", "CLIENTE_SISTEMA_ID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERFIL_API");

            migrationBuilder.DropTable(
                name: "TB_USUARIO_PERFIL");

            migrationBuilder.DropTable(
                name: "TB_API");

            migrationBuilder.DropTable(
                name: "TB_CLIENTE_SISTEMA");

            migrationBuilder.DropTable(
                name: "TB_PERFIL");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_SISTEMA");

            migrationBuilder.DropTable(
                name: "TB_CLIENTE");
        }
    }
}
