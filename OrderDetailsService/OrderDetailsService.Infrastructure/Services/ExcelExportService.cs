using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using OrderDetailsService.Application.DTOs;
using OrderDetailsService.Application.Interfaces;
using OrderDetailsService.Infrastructure.Repositories;

namespace OrderDetailsService.Infrastructure.Services
{
    /// <summary>
    /// Service for exporting order-related lists (items, observations, blocks, invoices) to Excel files.
    /// </summary>
    public class ExcelExportService : IExcelExportService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public ExcelExportService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        /// <inheritdoc />
        public async Task<byte[]> ExportListToExcelAsync(string orderNumber, string listType)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("Order number must be provided.", nameof(orderNumber));
            if (string.IsNullOrWhiteSpace(listType))
                throw new ArgumentException("List type must be provided.", nameof(listType));

            // Load the data for the requested list type
            DataTable dataTable = listType.ToLowerInvariant() switch
            {
                "items" => await GetOrderItemsDataTable(orderNumber),
                "observations" => await GetOrderObservationsDataTable(orderNumber),
                "blocks" => await GetOrderBlocksDataTable(orderNumber),
                "invoices" => await GetOrderInvoicesDataTable(orderNumber),
                _ => throw new ArgumentException($"Invalid list type: {listType}", nameof(listType))
            };

            // Generate Excel file
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Export");
            worksheet.Cell(1, 1).InsertTable(dataTable, "Export", true);

            // Autofit columns
            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        private async Task<DataTable> GetOrderItemsDataTable(string orderNumber)
        {
            var items = await _orderDetailsRepository.GetOrderItemsAsync(orderNumber);
            var dt = new DataTable("ItensPedido");

            dt.Columns.Add("Seq.", typeof(int));
            dt.Columns.Add("Cód.Prod. Cliente", typeof(string));
            dt.Columns.Add("Descr. Curta Prod.", typeof(string));
            dt.Columns.Add("Descr. Longa Prod.", typeof(string));
            dt.Columns.Add("Qtde Pedida", typeof(decimal));
            dt.Columns.Add("Qtde Faturada", typeof(decimal));
            dt.Columns.Add("Qtde Destinada", typeof(decimal));
            dt.Columns.Add("Qtde Empenhada", typeof(decimal));
            dt.Columns.Add("Situação", typeof(string));
            dt.Columns.Add("Preço", typeof(decimal));
            dt.Columns.Add("Saldo", typeof(decimal));
            dt.Columns.Add("Unitário", typeof(decimal));
            dt.Columns.Add("Desconto", typeof(decimal));
            dt.Columns.Add("Condição Pagamento", typeof(string));
            dt.Columns.Add("Tabela Preço", typeof(string));
            dt.Columns.Add("Data Base", typeof(string));
            dt.Columns.Add("Data Cedo", typeof(string));
            dt.Columns.Add("Data Tarde", typeof(string));
            dt.Columns.Add("Grupo Op.Fiscal", typeof(string));
            dt.Columns.Add("Oper. Fiscal", typeof(string));
            dt.Columns.Add("Grp Op.Fiscal Entrega", typeof(string));
            dt.Columns.Add("Oper. Fiscal Entrega", typeof(string));

            foreach (var item in items)
            {
                dt.Rows.Add(
                    item.SequentialId,
                    item.ProductCode,
                    item.ProductShortDescription,
                    item.ProductLongDescription,
                    item.OrderedQuantity ?? 0,
                    item.InvoicedQuantity ?? 0,
                    item.DestinedQuantity ?? 0,
                    item.CommittedQuantity ?? 0,
                    item.Status,
                    item.PriceValue ?? 0,
                    item.BalanceValue ?? 0,
                    item.UnitValue ?? 0,
                    item.Discount ?? 0,
                    item.PaymentCondition,
                    item.PriceTable,
                    item.BaseDate?.ToString("dd/MM/yyyy"),
                    item.EarlyDate?.ToString("dd/MM/yyyy"),
                    item.LateDate?.ToString("dd/MM/yyyy"),
                    item.FiscalGroupPricing,
                    item.FiscalOperationPricing,
                    item.FiscalGroupDelivery,
                    item.FiscalOperationDelivery
                );
            }

            return dt;
        }

        private async Task<DataTable> GetOrderObservationsDataTable(string orderNumber)
        {
            var observations = await _orderDetailsRepository.GetOrderObservationsAsync(orderNumber);
            var dt = new DataTable("ObservacoesPedido");

            dt.Columns.Add("Seq.", typeof(int));
            dt.Columns.Add("Tipo Operação", typeof(string));
            dt.Columns.Add("Inscrição Estadual Cliente", typeof(string));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Endereço", typeof(string));
            dt.Columns.Add("Cidade", typeof(string));
            dt.Columns.Add("UF", typeof(string));
            dt.Columns.Add("Município", typeof(string));
            dt.Columns.Add("MRH", typeof(string));
            dt.Columns.Add("Texto Nota Fiscal", typeof(string));
            dt.Columns.Add("Texto Livre", typeof(string));

            foreach (var obs in observations)
            {
                dt.Rows.Add(
                    obs.SequentialId,
                    obs.OperationTypeDescription,
                    obs.StateRegistration,
                    obs.Name,
                    obs.Address,
                    obs.City,
                    obs.State,
                    obs.Municipality,
                    obs.Mrh,
                    obs.InvoiceText,
                    obs.FreeText
                );
            }

            return dt;
        }

        private async Task<DataTable> GetOrderBlocksDataTable(string orderNumber)
        {
            var blocks = await _orderDetailsRepository.GetOrderBlocksAsync(orderNumber);
            var dt = new DataTable("BloqueiosPedido");

            dt.Columns.Add("Seq.", typeof(int));
            dt.Columns.Add("Descrição Bloqueio", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Data do Status", typeof(string));
            dt.Columns.Add("Mensagem", typeof(string));
            dt.Columns.Add("Tipo Bloqueio", typeof(string));

            foreach (var block in blocks)
            {
                dt.Rows.Add(
                    block.SequentialId,
                    block.BlockDescription,
                    block.Status == "A" ? "Ativo" : "Inativo",
                    block.StatusDate?.ToString("dd/MM/yyyy"),
                    block.Message,
                    block.BlockTypeDescription
                );
            }

            return dt;
        }

        private async Task<DataTable> GetOrderInvoicesDataTable(string orderNumber)
        {
            var invoices = await _orderDetailsRepository.GetOrderInvoicesAsync(orderNumber);
            var dt = new DataTable("NotasFiscais");

            dt.Columns.Add("Código", typeof(string));
            dt.Columns.Add("Série", typeof(string));
            dt.Columns.Add("Estabelecimento", typeof(string));
            dt.Columns.Add("Fábrica", typeof(string));
            dt.Columns.Add("Status NF", typeof(string));
            dt.Columns.Add("Tipo NF", typeof(string));
            dt.Columns.Add("Data Emissão", typeof(string));
            dt.Columns.Add("Data Saída Mercadoria", typeof(string));
            dt.Columns.Add("Valor BCICM", typeof(decimal));
            dt.Columns.Add("ICM", typeof(decimal));
            dt.Columns.Add("IPI", typeof(decimal));
            dt.Columns.Add("ALIQICM", typeof(decimal));
            dt.Columns.Add("Peso Líquido", typeof(decimal));
            dt.Columns.Add("Peso Bruto", typeof(decimal));
            dt.Columns.Add("Valor Descr.", typeof(decimal));
            dt.Columns.Add("Valor Total", typeof(decimal));
            dt.Columns.Add("Total Unidade Faturada", typeof(decimal));
            dt.Columns.Add("Qtde Volume", typeof(decimal));
            dt.Columns.Add("VIA Transporte", typeof(string));
            dt.Columns.Add("Descr. Transporte", typeof(string));
            dt.Columns.Add("Valor Descr. Pont.", typeof(decimal));
            dt.Columns.Add("Cód. Moeda", typeof(string));
            dt.Columns.Add("Qualidade", typeof(string));

            foreach (var inv in invoices)
            {
                dt.Rows.Add(
                    inv.InvoiceCode,
                    inv.Series,
                    inv.Establishment,
                    inv.FactoryDescription,
                    inv.StatusDescription,
                    inv.InvoiceType,
                    inv.EmissionDate?.ToString("dd/MM/yyyy"),
                    inv.MerchandiseExitDate?.ToString("dd/MM/yyyy"),
                    inv.IcmsBaseValue ?? 0,
                    inv.IcmsValue ?? 0,
                    inv.IpiValue ?? 0,
                    inv.IcmsAliquotValue ?? 0,
                    inv.NetWeight ?? 0,
                    inv.GrossWeight ?? 0,
                    inv.DiscountValue ?? 0,
                    inv.TotalValue ?? 0,
                    inv.TotalInvoicedUnits ?? 0,
                    inv.VolumeQuantity ?? 0,
                    inv.TransportWay,
                    inv.TransportDescription,
                    inv.AdditionalDiscountValue ?? 0,
                    inv.CurrencyCode,
                    inv.QualityDescription
                );
            }

            return dt;
        }
    }
}