using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services
{
    public interface IPedidoService
    {
        Task<Pedido> ObterDetalhesPedidoAsync(int pedidoId);
        Task<IEnumerable<ItemPedido>> ObterItensPedidoAsync(int pedidoId);
        Task<IEnumerable<Observacao>> ObterObservacoesPedidoAsync(int pedidoId);
        Task<IEnumerable<Bloqueio>> ObterBloqueiosPedidoAsync(int pedidoId);
        Task<IEnumerable<NotaFiscal>> ObterNotasFiscaisPedidoAsync(int pedidoId);
        Task<byte[]> ExportarDadosParaExcelAsync(int pedidoId, string aba);
    }
}
