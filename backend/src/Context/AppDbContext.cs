using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Observacao> Observacoes { get; set; }
        public DbSet<Bloqueio> Bloqueios { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de chaves e relacionamentos podem ser definidas aqui
            base.OnModelCreating(modelBuilder);
        }
    }
}
