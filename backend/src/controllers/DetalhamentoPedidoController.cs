using Microsoft.AspNetCore.Mvc;
using MyApp.Services;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalhamentoPedidoController : ControllerBase
    {
        private readonly IDetalhamentoPedidoService _detalhamentoPedidoService;

        public DetalhamentoPedidoController(IDetalhamentoPedidoService detalhamentoPedidoService)
        {
            _detalhamentoPedidoService = detalhamentoPedidoService;
        }

        // Endpoint para obter o detalhamento do pedido
        [HttpGet("{pedidoId}")]
        public async Task<IActionResult> ObterDetalhamentoPedido(int pedidoId, [FromQuery] bool carregarDetalhes = true)
        {
            try
            {
                var pedido = await _detalhamentoPedidoService.ObterDetalhamentoPedidoAsync(pedidoId, carregarDetalhes);
                return Ok(pedido);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno do servidor.", detalhes = ex.Message });
            }
        }
    }
}
