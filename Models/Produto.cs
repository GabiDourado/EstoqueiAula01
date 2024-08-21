using Analista_Aula01.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Analista_Aula01.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("ProdutoId")]
        public int ProdutoId { get; set; }

        [Column("ProdutoNome")]
        [Display(Name = "Nome do produto")]
        public string ProdutoNome { get; set; } = string.Empty;

        [Column("ProdutoPeso")]
        [Display(Name = "Peso do produto")]
        public int ProdutoPeso { get; set; }

        [Column("QntdEstoque")]
        [Display(Name = "Quantidade em estoque")]
        public int QntdEstoque { get; set; }

        [Column("StatusProduto")]
        [Display(Name = "Status do Produto")]
        public bool StatusProduto { get; set; }

        [ForeignKey("TipoProdutoId")]
        public int TipoProdutoId { get; set; }
        public TipoProduto? TipoProduto { get; set; }
    }
}
