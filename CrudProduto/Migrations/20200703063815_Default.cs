using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudProduto.Migrations
{
    public partial class Default : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FichaTecnica",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(nullable: true),
                    componenteBasico = table.Column<string>(nullable: true),
                    componentePrimario = table.Column<string>(nullable: true),
                    componenteSecundario = table.Column<string>(nullable: true),
                    categoria = table.Column<string>(nullable: true),
                    subCategoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaTecnica", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LinhaProduto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaProduto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataHora = table.Column<DateTime>(nullable: false),
                    idUsuario = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    senha1 = table.Column<string>(nullable: true),
                    senha2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    valorCompra = table.Column<double>(nullable: false),
                    dataCompra = table.Column<DateTime>(nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    comprador = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    fichaTecnicaid = table.Column<int>(nullable: true),
                    linhaprodutoid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produto_FichaTecnica_fichaTecnicaid",
                        column: x => x.fichaTecnicaid,
                        principalTable: "FichaTecnica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_LinhaProduto_linhaprodutoid",
                        column: x => x.linhaprodutoid,
                        principalTable: "LinhaProduto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acessorio",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    quantidade = table.Column<int>(nullable: false),
                    LinhaProdutoid = table.Column<int>(nullable: true),
                    Produtoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessorio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Acessorio_LinhaProduto_LinhaProdutoid",
                        column: x => x.LinhaProdutoid,
                        principalTable: "LinhaProduto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acessorio_Produto_Produtoid",
                        column: x => x.Produtoid,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acessorio_LinhaProdutoid",
                table: "Acessorio",
                column: "LinhaProdutoid");

            migrationBuilder.CreateIndex(
                name: "IX_Acessorio_Produtoid",
                table: "Acessorio",
                column: "Produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_fichaTecnicaid",
                table: "Produto",
                column: "fichaTecnicaid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_linhaprodutoid",
                table: "Produto",
                column: "linhaprodutoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acessorio");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "FichaTecnica");

            migrationBuilder.DropTable(
                name: "LinhaProduto");
        }
    }
}
