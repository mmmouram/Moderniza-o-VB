using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> ObterPedidoPorIdAsync(int pedidoId);
        Task<IEnumerable<PedidoItem>> ObterItensPedidoAsync(int pedidoId);
        Task<IEnumerable<Observacao>> ObterObservacoesPedidoAsync(int pedidoId);
        Task<IEnumerable<Bloqueio>> ObterBloqueiosPedidoAsync(int pedidoId);
        Task<IEnumerable<NotaFiscal>> ObterNotasFiscaisPedidoAsync(int pedidoId);
    }
}
