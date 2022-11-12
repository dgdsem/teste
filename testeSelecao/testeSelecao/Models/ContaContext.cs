using System.Data.Entity;

namespace testeSelecao.Models
{
    public class ContaContext: DbContext
    {
        public DbSet<Conta> Contas { get; set; }
    }
}
