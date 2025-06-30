using System.Threading.Tasks;
using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> ObterPedidoAsync(int pedidoId);
        Task<IEnumerable<ItemPedido>> ObterItensPedidoAsync(int pedidoId);
        Task<IEnumerable<Observacao>> ObterObservacoesPedidoAsync(int pedidoId);
        Task<IEnumerable<Bloqueio>> ObterBloqueiosPedidoAsync(int pedidoId);
        Task<IEnumerable<NotaFiscal>> ObterNotasFiscaisPedidoAsync(int pedidoId);

        // Métodos para atualizar os dados se necessário
        Task AtualizarPedidoAsync(Pedido pedido);
    }
}
