using MyApp.Models;
using System.Threading.Tasks;

namespace MyApp.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> ObterPedidoPorIdAsync(int pedidoId, bool carregarDetalhes);
    }
}
