using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudProduto.Migrations
{
    public partial class M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessorioBasico");

            migrationBuilder.DropTable(
                name: "AcessorioOpcional");

            migrationBuilder.CreateTable(
                name: "Acessorio",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descLog = table.Column<string>(nullable: true),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acessorio");

            migrationBuilder.CreateTable(
                name: "AcessorioBasico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descLog = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    linhaProdutoid = table.Column<int>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessorioBasico", x => x.id);
                    table.ForeignKey(
                        name: "FK_AcessorioBasico_LinhaProduto_linhaProdutoid",
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
                    descricao = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    produtoid = table.Column<int>(nullable: true),
                    quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessorioOpcional", x => x.id);
                    table.ForeignKey(
                        name: "FK_AcessorioOpcional_Produto_produtoid",
                        column: x => x.produtoid,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcessorioBasico_linhaProdutoid",
                table: "AcessorioBasico",
                column: "linhaProdutoid");

            migrationBuilder.CreateIndex(
                name: "IX_AcessorioOpcional_produtoid",
                table: "AcessorioOpcional",
                column: "produtoid");
        }
    }
}
