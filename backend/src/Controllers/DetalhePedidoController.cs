using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalhePedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public DetalhePedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Retorna os detalhes do cabeçalho do pedido (Número, CNPJ e Razão Social).
        /// </summary>
        [HttpGet("{pedidoId}")]
        public async Task<IActionResult> ObterDetalhesPedido(int pedidoId)
        {
            var pedido = await _pedidoService.ObterDetalhesPedidoAsync(pedidoId);
            return Ok(new
            {
                pedido.PedidoId,
                pedido.NumeroPedido,
                pedido.Cnpj,
                pedido.RazaoSocial
            });
        }

        /// <summary>
        /// Retorna a listagem de Itens do Pedido.
        /// Se carregarAutomaticamente for true, os dados são carregados automaticamente.
        /// Caso contrário, espera atualização manual.
        /// </summary>
        [HttpGet("{pedidoId}/itens")]
        public async Task<IActionResult> ObterItensPedido(int pedidoId, [FromQuery] bool carregarAutomaticamente = true)
        {
            // A lógica de "carregar automaticamente" pode ser tratada na camada de front-end.
            var itens = await _pedidoService.ObterItensPedidoAsync(pedidoId);
            return Ok(itens);
        }

        [HttpGet("{pedidoId}/observacoes")]
        public async Task<IActionResult> ObterObservacoesPedido(int pedidoId, [FromQuery] bool carregarAutomaticamente = true)
        {
            var observacoes = await _pedidoService.ObterObservacoesPedidoAsync(pedidoId);
            return Ok(observacoes);
        }

        [HttpGet("{pedidoId}/bloqueios")]
        public async Task<IActionResult> ObterBloqueiosPedido(int pedidoId, [FromQuery] bool carregarAutomaticamente = true)
        {
            var bloqueios = await _pedidoService.ObterBloqueiosPedidoAsync(pedidoId);
            return Ok(bloqueios);
        }

        [HttpGet("{pedidoId}/notasfiscais")]
        public async Task<IActionResult> ObterNotasFiscaisPedido(int pedidoId, [FromQuery] bool carregarAutomaticamente = true)
        {
            var notas = await _pedidoService.ObterNotasFiscaisPedidoAsync(pedidoId);
            return Ok(notas);
        }

        /// <summary>
        /// Exporta os dados de uma aba específica para Excel.
        /// </summary>
        [HttpGet("{pedidoId}/exportar")]
        public async Task<IActionResult> ExportarParaExcel(int pedidoId, [FromQuery] string aba)
        {
            var arquivoExcel = await _pedidoService.ExportarDadosParaExcelAsync(pedidoId, aba);
            // Retorna o arquivo com o content-type adequado
            return File(arquivoExcel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"pedido_{pedidoId}_{aba}.xlsx");
        }
    }
}
