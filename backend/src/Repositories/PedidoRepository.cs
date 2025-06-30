using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> ObterPedidoAsync(int pedidoId)
        {
            return await _context.Pedidos
                .Include(p => p.ItensPedido)
                .Include(p => p.Observacoes)
                .Include(p => p.Bloqueios)
                .Include(p => p.NotasFiscais)
                .FirstOrDefaultAsync(p => p.PedidoId == pedidoId);
        }

        public async Task<IEnumerable<ItemPedido>> ObterItensPedidoAsync(int pedidoId)
        {
            return await _context.ItensPedido
                .Where(ip => ip.PedidoId == pedidoId)
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

        public async Task AtualizarPedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
