using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Analista_Aula01.Models
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Column("TipoProdutoId")]
        [Display(Name = "Código do tipo do produto")]
        public int TipoProdutoId { get; set; }

        [Column("NomeTipoProduto")]
        [Display(Name = "Nome do Tipo do produto")]
        public string NomeTipoProduto { get; set; } = string.Empty;

    }
}
