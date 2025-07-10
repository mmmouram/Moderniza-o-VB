using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using MyApp.Models;
using MyApp.Repositories;

namespace MyApp.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> ObterDetalhesPedidoAsync(int pedidoId)
        {
            return await _pedidoRepository.ObterPedidoPorIdAsync(pedidoId);
        }

        public async Task<IEnumerable<PedidoItem>> ObterItensPedidoAsync(int pedidoId)
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

        public byte[] ExportarParaExcel<T>(IEnumerable<T> dados)
        {
            if (dados == null || !dados.Any())
            {
                throw new Exception("Não há dados para exportar.");
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Dados");
                var properties = typeof(T).GetProperties();

                // Cabeçalho
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = properties[i].Name;
                }

                int row = 2;
                foreach (var item in dados)
                {
                    for (int col = 0; col < properties.Length; col++)
                    {
                        worksheet.Cell(row, col + 1).Value = properties[col].GetValue(item)?.ToString();
                    }
                    row++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        public async Task<NotaFiscal> DetalharNotaFiscalAsync(int pedidoId, int notaFiscalId)
        {
            var notas = await _pedidoRepository.ObterNotasFiscaisPedidoAsync(pedidoId);
            var nota = notas.FirstOrDefault(n => n.Id == notaFiscalId);
            if (nota == null)
            {
                throw new Exception("Nota Fiscal não encontrada.");
            }
            return nota;
        }
    }
}
