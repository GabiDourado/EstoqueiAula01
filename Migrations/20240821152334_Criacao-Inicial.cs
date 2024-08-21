using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analista_Aula01.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoMovimentacao",
                columns: table => new
                {
                    TipoMovimentacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoMovimentacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimentacao", x => x.TipoMovimentacaoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoProduto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProduto", x => x.TipoProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdutoPeso = table.Column<int>(type: "int", nullable: false),
                    QntdEstoque = table.Column<int>(type: "int", nullable: false),
                    StatusProduto = table.Column<bool>(type: "bit", nullable: false),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produto_TipoProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TipoProduto",
                        principalColumn: "TipoProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntradaSaida",
                columns: table => new
                {
                    EntradaSaidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    QntdMovimentacao = table.Column<int>(type: "int", nullable: false),
                    TipoMovimentacaoId = table.Column<int>(type: "int", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaSaida", x => x.EntradaSaidaId);
                    table.ForeignKey(
                        name: "FK_EntradaSaida_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradaSaida_TipoMovimentacao_TipoMovimentacaoId",
                        column: x => x.TipoMovimentacaoId,
                        principalTable: "TipoMovimentacao",
                        principalColumn: "TipoMovimentacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaSaida_ProdutoId",
                table: "EntradaSaida",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaSaida_TipoMovimentacaoId",
                table: "EntradaSaida",
                column: "TipoMovimentacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_TipoProdutoId",
                table: "Produto",
                column: "TipoProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaSaida");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "TipoMovimentacao");

            migrationBuilder.DropTable(
                name: "TipoProduto");
        }
    }
}
