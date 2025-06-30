using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> ObterDetalhesPedidoAsync(int pedidoId)
        {
            var pedido = await _pedidoRepository.ObterPedidoAsync(pedidoId);
            if (pedido == null)
                throw new Exception($"Pedido com ID {pedidoId} não encontrado.");
            
            // Validação e formatação de datas e valores pode ser feita aqui
            return pedido;
        }

        public async Task<IEnumerable<ItemPedido>> ObterItensPedidoAsync(int pedidoId)
        {
            return await _pedidoRepository.ObterItensPedidoAsync(pedidoId);
        }

        public async Task<IEnumerable<Observacao>> ObterObservacoesPedidoAsync(int pedidoId)
        {
            return await _pedidoRepository.ObterObservacoesPedidoAsync(pedidoId);
        }

        public async Task<IEnumerable<Bloqueio>> ObterBloqueiosPedidoAsync(int pedidoId)
        {
            return await _pedidoRepository.ObterBloqueiosPedidoAsync(pedidoId);
        }

        public async Task<IEnumerable<NotaFiscal>> ObterNotasFiscaisPedidoAsync(int pedidoId)
        {
            return await _pedidoRepository.ObterNotasFiscaisPedidoAsync(pedidoId);
        }

        public async Task<byte[]> ExportarDadosParaExcelAsync(int pedidoId, string aba)
        {
            // Lógica para geração de Excel com base na aba informada
            // Essa implementação é simplificada e deve ser adaptada para uso de uma biblioteca real, como EPPlus ou ClosedXML
            // Aqui retornamos um array de bytes vazio para simular a exportação
            await Task.CompletedTask;
            return new byte[0];
        }
    }
}
