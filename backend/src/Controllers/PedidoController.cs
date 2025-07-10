using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Services;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // Cenário 1: Exibição de dados do pedido
        [HttpGet("{pedidoId}/detalhes")]
        public async Task<IActionResult> ObterDetalhesPedido(int pedidoId)
        {
            var pedido = await _pedidoService.ObterDetalhesPedidoAsync(pedidoId);
            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }
            
            var resposta = new
            {
                pedido.NumeroPedido,
                pedido.Cnpj,
                pedido.RazaoSocial
            };

            return Ok(resposta);
        }

        // Cenário 2 e 3: Carregamento automático e atualização manual dos itens
        [HttpGet("{pedidoId}/itens")]
        public async Task<IActionResult> ObterItensPedido(int pedidoId, [FromQuery] bool autoCarregar = false)
        {
            var itens = await _pedidoService.ObterItensPedidoAsync(pedidoId);
            if (itens == null || !itens.Any())
            {
                return NotFound("Nenhum item encontrado para o pedido.");
            }
            return Ok(itens);
        }

        [HttpGet("{pedidoId}/observacoes")]
        public async Task<IActionResult> ObterObservacoesPedido(int pedidoId, [FromQuery] bool autoCarregar = false)
        {
            var observacoes = await _pedidoService.ObterObservacoesPedidoAsync(pedidoId);
            if (observacoes == null || !observacoes.Any())
            {
                return NotFound("Nenhuma observação encontrada para o pedido.");
            }
            return Ok(observacoes);
        }

        [HttpGet("{pedidoId}/bloqueios")]
        public async Task<IActionResult> ObterBloqueiosPedido(int pedidoId, [FromQuery] bool autoCarregar = false)
        {
            var bloqueios = await _pedidoService.ObterBloqueiosPedidoAsync(pedidoId);
            if (bloqueios == null || !bloqueios.Any())
            {
                return NotFound("Nenhum bloqueio encontrado para o pedido.");
            }
            return Ok(bloqueios);
        }

        [HttpGet("{pedidoId}/notasfiscais")]
        public async Task<IActionResult> ObterNotasFiscaisPedido(int pedidoId, [FromQuery] bool autoCarregar = false)
        {
            var notas = await _pedidoService.ObterNotasFiscaisPedidoAsync(pedidoId);
            if (notas == null || !notas.Any())
            {
                return NotFound("Nenhuma Nota Fiscal encontrada para o pedido.");
            }
            return Ok(notas);
        }

        // Cenário 4 e 5: Exportação de dados para Excel
        [HttpPost("{pedidoId}/exportar")]
        public async Task<IActionResult> ExportarParaExcel(int pedidoId, [FromQuery] string aba)
        {
            try
            {
                byte[] arquivoBytes;
                switch (aba?.ToLower())
                {
                    case "itens":
                        var itens = await _pedidoService.ObterItensPedidoAsync(pedidoId);
                        arquivoBytes = _pedidoService.ExportarParaExcel(itens);
                        break;
                    case "observacoes":
                        var observacoes = await _pedidoService.ObterObservacoesPedidoAsync(pedidoId);
                        arquivoBytes = _pedidoService.ExportarParaExcel(observacoes);
                        break;
                    case "bloqueios":
                        var bloqueios = await _pedidoService.ObterBloqueiosPedidoAsync(pedidoId);
                        arquivoBytes = _pedidoService.ExportarParaExcel(bloqueios);
                        break;
                    case "notasfiscais":
                        var notas = await _pedidoService.ObterNotasFiscaisPedidoAsync(pedidoId);
                        arquivoBytes = _pedidoService.ExportarParaExcel(notas);
                        break;
                    default:
                        return BadRequest("Aba inválida para exportação.");
                }

                return File(arquivoBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{aba}_pedido_{pedidoId}.xlsx");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Cenário 6: Detalhamento de Nota Fiscal
        [HttpGet("{pedidoId}/notasfiscais/{notaFiscalId}")]
        public async Task<IActionResult> DetalharNotaFiscal(int pedidoId, int notaFiscalId)
        {
            try
            {
                var nota = await _pedidoService.DetalharNotaFiscalAsync(pedidoId, notaFiscalId);
                return Ok(nota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
