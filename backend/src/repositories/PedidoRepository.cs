using Microsoft.EntityFrameworkCore;
using MyApp.Config;
using MyApp.Models;
using System.Threading.Tasks;

namespace MyApp.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> ObterPedidoPorIdAsync(int pedidoId, bool carregarDetalhes)
        {
            if (carregarDetalhes)
            {
                return await _context.Pedidos
                    .Include(p => p.Itens)
                    .Include(p => p.Observacoes)
                    .Include(p => p.Bloqueios)
                    .Include(p => p.NotasFiscais)
                    .FirstOrDefaultAsync(p => p.Id == pedidoId);
            }
            else
            {
                return await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == pedidoId);
            }
        }
    }
}
