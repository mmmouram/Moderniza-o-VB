using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Context;
using MyApp.Models;

namespace MyApp.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> ObterPedidoPorIdAsync(int pedidoId)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == pedidoId);
        }

        public async Task<IEnumerable<PedidoItem>> ObterItensPedidoAsync(int pedidoId)
        {
            return await _context.PedidoItems
                .Where(item => item.PedidoId == pedidoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Observacao>> ObterObservacoesPedidoAsync(int pedidoId)
        {
            return await _context.Observacoes
                .Where(o => o.PedidoId == pedidoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bloqueio>> ObterBloqueiosPedidoAsync(int pedidoId)
        {
            return await _context.Bloqueios
                .Where(b => b.PedidoId == pedidoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<NotaFiscal>> ObterNotasFiscaisPedidoAsync(int pedidoId)
        {
            return await _context.NotasFiscais
                .Where(nf => nf.PedidoId == pedidoId)
                .ToListAsync();
        }
    }
}
