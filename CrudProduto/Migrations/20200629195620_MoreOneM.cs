using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudProduto.Migrations
{
    public partial class MoreOneM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descLog",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "descLog",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "descLog",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "descLog",
                table: "LinhaProduto");

            migrationBuilder.DropColumn(
                name: "descLog",
                table: "FichaTecnica");

            migrationBuilder.DropColumn(
                name: "descLog",
                table: "Acessorio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descLog",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descLog",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descLog",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descLog",
                table: "LinhaProduto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descLog",
                table: "FichaTecnica",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descLog",
                table: "Acessorio",
                nullable: true);
        }
    }
}
