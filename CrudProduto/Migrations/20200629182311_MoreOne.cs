using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudProduto.Migrations
{
    public partial class MoreOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcessorioBasico_LinhaProduto_linhaPrdoutoid",
                table: "AcessorioBasico");

            migrationBuilder.DropForeignKey(
                name: "FK_AcessorioOpcional_Produto_Produtoid",
                table: "AcessorioOpcional");

            migrationBuilder.DropForeignKey(
                name: "FK_AcessorioOpcional_LinhaProduto_linhaPrdoutoid",
                table: "AcessorioOpcional");

            migrationBuilder.DropIndex(
                name: "IX_AcessorioOpcional_linhaPrdoutoid",
                table: "AcessorioOpcional");

            migrationBuilder.DropColumn(
                name: "linhaPrdoutoid",
                table: "AcessorioOpcional");

            migrationBuilder.RenameColumn(
                name: "Produtoid",
                table: "AcessorioOpcional",
                newName: "produtoid");

            migrationBuilder.RenameIndex(
                name: "IX_AcessorioOpcional_Produtoid",
                table: "AcessorioOpcional",
                newName: "IX_AcessorioOpcional_produtoid");

            migrationBuilder.RenameColumn(
                name: "linhaPrdoutoid",
                table: "AcessorioBasico",
                newName: "linhaProdutoid");

            migrationBuilder.RenameIndex(
                name: "IX_AcessorioBasico_linhaPrdoutoid",
                table: "AcessorioBasico",
                newName: "IX_AcessorioBasico_linhaProdutoid");

            migrationBuilder.AddForeignKey(
                name: "FK_AcessorioBasico_LinhaProduto_linhaProdutoid",
                table: "AcessorioBasico",
                column: "linhaProdutoid",
                principalTable: "LinhaProduto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AcessorioOpcional_Produto_produtoid",
                table: "AcessorioOpcional",
                column: "produtoid",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcessorioBasico_LinhaProduto_linhaProdutoid",
                table: "AcessorioBasico");

            migrationBuilder.DropForeignKey(
                name: "FK_AcessorioOpcional_Produto_produtoid",
                table: "AcessorioOpcional");

            migrationBuilder.RenameColumn(
                name: "produtoid",
                table: "AcessorioOpcional",
                newName: "Produtoid");

            migrationBuilder.RenameIndex(
                name: "IX_AcessorioOpcional_produtoid",
                table: "AcessorioOpcional",
                newName: "IX_AcessorioOpcional_Produtoid");

            migrationBuilder.RenameColumn(
                name: "linhaProdutoid",
                table: "AcessorioBasico",
                newName: "linhaPrdoutoid");

            migrationBuilder.RenameIndex(
                name: "IX_AcessorioBasico_linhaProdutoid",
                table: "AcessorioBasico",
                newName: "IX_AcessorioBasico_linhaPrdoutoid");

            migrationBuilder.AddColumn<int>(
                name: "linhaPrdoutoid",
                table: "AcessorioOpcional",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcessorioOpcional_linhaPrdoutoid",
                table: "AcessorioOpcional",
                column: "linhaPrdoutoid");

            migrationBuilder.AddForeignKey(
                name: "FK_AcessorioBasico_LinhaProduto_linhaPrdoutoid",
                table: "AcessorioBasico",
                column: "linhaPrdoutoid",
                principalTable: "LinhaProduto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AcessorioOpcional_Produto_Produtoid",
                table: "AcessorioOpcional",
                column: "Produtoid",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AcessorioOpcional_LinhaProduto_linhaPrdoutoid",
                table: "AcessorioOpcional",
                column: "linhaPrdoutoid",
                principalTable: "LinhaProduto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
