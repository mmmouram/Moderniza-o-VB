using MyApp.Models;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface IDetalhamentoPedidoService
    {
        Task<Pedido> ObterDetalhamentoPedidoAsync(int pedidoId, bool carregarDetalhes);
    }
}
