using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<PedidoBloqueio> PedidoBloqueios { get; set; }
        public DbSet<Observacao> Observacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais de relacionamento se necessário
        }
    }
}
