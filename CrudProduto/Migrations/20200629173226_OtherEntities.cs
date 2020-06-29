using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudProduto.Migrations
{
    public partial class OtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descLog",
                table: "AcessorioBasico",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "linhaPrdoutoid",
                table: "AcessorioBasico",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FichaTecnica",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descLog = table.Column<string>(nullable: true),
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
                    descLog = table.Column<string>(nullable: true),
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
                    descLog = table.Column<string>(nullable: true),
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
                    descLog = table.Column<string>(nullable: true),
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
                    descLog = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    valorCompra = table.Column<double>(nullable: false),
                    dataCompra = table.Column<DateTime>(nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    comprador = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    fichaTecnicaid = table.Column<int>(nullable: true),
                    linhaProdutoid = table.Column<int>(nullable: true)
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
                        name: "FK_Produto_LinhaProduto_linhaProdutoid",
                        column: x => x.linhaProdutoid,
                        principalTable: "LinhaProduto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcessorioOpcional",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descLog = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    quantidade = table.Column<int>(nullable: false),
                    linhaPrdoutoid = table.Column<int>(nullable: true),
                    Produtoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessorioOpcional", x => x.id);
                    table.ForeignKey(
                        name: "FK_AcessorioOpcional_Produto_Produtoid",
                        column: x => x.Produtoid,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcessorioOpcional_LinhaProduto_linhaPrdoutoid",
                        column: x => x.linhaPrdoutoid,
                        principalTable: "LinhaProduto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcessorioBasico_linhaPrdoutoid",
                table: "AcessorioBasico",
                column: "linhaPrdoutoid");

            migrationBuilder.CreateIndex(
                name: "IX_AcessorioOpcional_Produtoid",
                table: "AcessorioOpcional",
                column: "Produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_AcessorioOpcional_linhaPrdoutoid",
                table: "AcessorioOpcional",
                column: "linhaPrdoutoid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_fichaTecnicaid",
                table: "Produto",
                column: "fichaTecnicaid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_linhaProdutoid",
                table: "Produto",
                column: "linhaProdutoid");

            migrationBuilder.AddForeignKey(
                name: "FK_AcessorioBasico_LinhaProduto_linhaPrdoutoid",
                table: "AcessorioBasico",
                column: "linhaPrdoutoid",
                principalTable: "LinhaProduto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcessorioBasico_LinhaProduto_linhaPrdoutoid",
                table: "AcessorioBasico");

            migrationBuilder.DropTable(
                name: "AcessorioOpcional");

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

            migrationBuilder.DropIndex(
                name: "IX_AcessorioBasico_linhaPrdoutoid",
                table: "AcessorioBasico");

            migrationBuilder.DropColumn(
                name: "descLog",
                table: "AcessorioBasico");

            migrationBuilder.DropColumn(
                name: "linhaPrdoutoid",
                table: "AcessorioBasico");
        }
    }
}
