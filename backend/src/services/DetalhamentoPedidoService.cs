using MyApp.Models;
using MyApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class DetalhamentoPedidoService : IDetalhamentoPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public DetalhamentoPedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> ObterDetalhamentoPedidoAsync(int pedidoId, bool carregarDetalhes)
        {
            var pedido = await _pedidoRepository.ObterPedidoPorIdAsync(pedidoId, carregarDetalhes);
            if (pedido == null)
            {
                throw new KeyNotFoundException("Pedido não encontrado.");
            }
            return pedido;
        }
    }
}
