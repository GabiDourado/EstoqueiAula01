using Analista_Aula01.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Azure.Core.HttpHeader;

namespace Analista_Aula01.Models
{
    [Table("EntradaSaida")]
    public class EntradaSaida
    {
        [Column("EntradaSaidaId")]
        public int EntradaSaidaId { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Column("QntdMovimentacao")]
        [Display(Name = "Quantidade de movimentação")]
        public int QntdMovimentacao { get; set; }

        [ForeignKey("TipoMovimentacaoId")]
        public int TipoMovimentacaoId { get; set; }
        public TipoMovimentacao? TipoMovimentacao { get; set; }

        [Column("DataMovimentacao")]
        [Display(Name = "Data da movimentação")]
        public DateTime DataMovimentacao { get; set; }
    }
}
