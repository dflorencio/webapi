using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categoria_CategoriaID",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "CategoriaID",
                table: "Produtos",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaID",
                table: "Produtos",
                newName: "IX_Produtos_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categoria_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categoria_CategoriaId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Produtos",
                newName: "CategoriaID");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                newName: "IX_Produtos_CategoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categoria_CategoriaID",
                table: "Produtos",
                column: "CategoriaID",
                principalTable: "Categoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
