using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Analista_Aula01.Models
{
    [Table("TipoMovimentacao")]
    public class TipoMovimentacao
    {
        [Column("TipoMovimentacaoId")]
        public int TipoMovimentacaoId { get; set; }

        [Column("NomeTipoMovimentacao")]
        [Display(Name = "Nome do tipo de movimentação")]
        public string NomeTipoMovimentacao { get; set; } = string.Empty;
    }
}
