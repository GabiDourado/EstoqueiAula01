using Microsoft.EntityFrameworkCore;

namespace Analista_Aula01.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
           
        }

       public DbSet<TipoProduto> TipoProduto { get; set; }
       public DbSet<Produto> Produto { get; set; }
       public DbSet<TipoMovimentacao> TipoMovimentacao { get; set; }
       public DbSet<EntradaSaida> EntradaSaida { get; set; }

    }
}
