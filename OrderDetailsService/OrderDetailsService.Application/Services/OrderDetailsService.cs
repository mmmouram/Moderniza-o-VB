using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderDetailsService.Application.DTOs;
using OrderDetailsService.Application.Interfaces;
using OrderDetailsService.Domain.Entities;
using OrderDetailsService.Infrastructure.Repositories;

namespace OrderDetailsService.Application.Services
{
    /// <summary>
    /// Service responsible for all business logic related to the modernized Order Details form,
    /// including retrieval, update, export, and state persistence for order details, items, observations, blocks, and invoices.
    /// </summary>
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IExcelExportService _excelExportService;
        private readonly IStatePersistenceService _statePersistenceService;

        public OrderDetailsService(
            IOrderDetailsRepository orderDetailsRepository,
            IExcelExportService excelExportService,
            IStatePersistenceService statePersistenceService)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _excelExportService = excelExportService;
            _statePersistenceService = statePersistenceService;
        }

        /// <inheritdoc />
        public async Task<OrderDetailsDto> GetOrderDetailsAsync(string orderNumber)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("Order number must be provided.", nameof(orderNumber));

            // Retrieve order and all related data
            var order = await _orderDetailsRepository.GetOrderWithDetailsAsync(orderNumber);
            if (order == null)
                throw new KeyNotFoundException($"Order '{orderNumber}' not found.");

            // Retrieve persisted state (positions, checkboxes)
            var state = await _statePersistenceService.GetPersistedStateAsync(orderNumber);

            // Map to DTO
            var dto = MapOrderToDto(order, state);

            return dto;
        }

        /// <inheritdoc />
        public async Task<OrderItemDto[]> UpdateOrderItemsAsync(string orderNumber)
        {
            var items = await _orderDetailsRepository.GetOrderItemsAsync(orderNumber);
            return items.Select(MapOrderItemToDto).ToArray();
        }

        /// <inheritdoc />
        public async Task<OrderObservationDto[]> UpdateOrderObservationsAsync(string orderNumber)
        {
            var observations = await _orderDetailsRepository.GetOrderObservationsAsync(orderNumber);
            return observations.Select(MapOrderObservationToDto).ToArray();
        }

        /// <inheritdoc />
        public async Task<OrderBlockDto[]> UpdateOrderBlocksAsync(string orderNumber)
        {
            var blocks = await _orderDetailsRepository.GetOrderBlocksAsync(orderNumber);
            return blocks.Select(MapOrderBlockToDto).ToArray();
        }

        /// <inheritdoc />
        public async Task<OrderInvoiceDto[]> UpdateOrderInvoicesAsync(string orderNumber)
        {
            var invoices = await _orderDetailsRepository.GetOrderInvoicesAsync(orderNumber);
            return invoices.Select(MapOrderInvoiceToDto).ToArray();
        }

        /// <inheritdoc />
        public async Task<byte[]> ExportListToExcelAsync(string orderNumber, string listType)
        {
            return await _excelExportService.ExportListToExcelAsync(orderNumber, listType);
        }

        /// <inheritdoc />
        public async Task PersistStateAsync(string orderNumber, OrderDetailStatePersistenceDto state)
        {
            await _statePersistenceService.PersistStateAsync(orderNumber, state);
        }

        /// <inheritdoc />
        public async Task<OrderDetailStatePersistenceDto> GetPersistedStateAsync(string orderNumber)
        {
            return await _statePersistenceService.GetPersistedStateAsync(orderNumber);
        }

        /// <inheritdoc />
        public async Task<ExportToSapResponse> ExportToSapAsync(string orderNumber)
        {
            // Simulação de exportação para SAP.
            // Em um cenário real, aqui seria feita a integração com o SAP (ex: via RFC, API REST, etc).
            // Para este exemplo, apenas retorna sucesso e um número fictício de documento SAP.

            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("Order number must be provided.", nameof(orderNumber));

            // Aqui você pode adicionar lógica real de integração SAP.
            // Exemplo: var sapResult = await _sapIntegrationService.ExportOrderAsync(orderNumber);

            // Simulação de sucesso:
            var response = new ExportToSapResponse
            {
                Success = true,
                Message = $"Pedido {orderNumber} exportado com sucesso para o SAP.",
                SapDocumentNumber = $"SAP{orderNumber.PadLeft(10, '0')}"
            };

            return await Task.FromResult(response);
        }

        #region Mapping Methods

        private static OrderDetailsDto MapOrderToDto(Order order, OrderDetailStatePersistenceDto state)
        {
            return new OrderDetailsDto
            {
                OrderNumber = order.OrderNumber,
                ClientCnpj = order.ClientCnpj,
                ClientRazaoSocial = order.ClientRazaoSocial,
                InclusionDate = order.InclusionDate,
                Establishment = order.Establishment,
                ClientCode = order.ClientCode,
                TransportDescription = order.TransportDescription,
                LastUpdateDate = order.LastUpdateDate,
                ClientOrderNumber = order.ClientOrderNumber,
                Post = order.Post,
                TotalOrderValue = order.TotalOrderValue,
                CommercialConditionDescription = order.CommercialConditionDescription,
                BillingStatusDescription = order.BillingStatusDescription,
                OrderStatusCode = order.OrderStatusCode,
                OrderStatusDescription = order.OrderStatusDescription,
                RequiredDate = order.RequiredDate,
                Items = order.Items?.Select(MapOrderItemToDto).ToList() ?? new List<OrderItemDto>(),
                Observations = order.Observations?.Select(MapOrderObservationToDto).ToList() ?? new List<OrderObservationDto>(),
                Blocks = order.Blocks?.Select(MapOrderBlockToDto).ToList() ?? new List<OrderBlockDto>(),
                Invoices = order.Invoices?.Select(MapOrderInvoiceToDto).ToList() ?? new List<OrderInvoiceDto>(),
                AutoLoadItems = order.AutoLoadItems,
                AutoLoadObservations = order.AutoLoadObservations,
                AutoLoadBlocks = order.AutoLoadBlocks,
                AutoLoadInvoices = order.AutoLoadInvoices,
                StatePersistence = state ?? new OrderDetailStatePersistenceDto()
            };
        }

        private static OrderItemDto MapOrderItemToDto(OrderItem item)
        {
            return new OrderItemDto
            {
                OrderNumber = item.OrderNumber,
                ProductCode = item.ProductCode,
                SequentialId = item.SequentialId,
                OrderedQuantity = item.OrderedQuantity,
                InvoicedQuantity = item.InvoicedQuantity,
                DestinedQuantity = item.DestinedQuantity,
                CommittedQuantity = item.CommittedQuantity,
                Status = item.Status,
                PriceValue = item.PriceValue,
                BalanceValue = item.BalanceValue,
                UnitValue = item.UnitValue,
                Discount = item.Discount,
                PaymentCondition = item.PaymentCondition,
                PriceTable = item.PriceTable,
                FiscalGroupPricing = item.FiscalGroupPricing,
                FiscalOperationPricing = item.FiscalOperationPricing,
                FiscalGroupDelivery = item.FiscalGroupDelivery,
                FiscalOperationDelivery = item.FiscalOperationDelivery,
                EarlyDate = item.EarlyDate,
                LateDate = item.LateDate,
                BaseDate = item.BaseDate,
                ProductShortDescription = item.ProductShortDescription,
                ProductLongDescription = item.ProductLongDescription
            };
        }

        private static OrderObservationDto MapOrderObservationToDto(OrderObservation obs)
        {
            return new OrderObservationDto
            {
                OrderNumber = obs.OrderNumber,
                SequentialId = obs.SequentialId,
                OperationTypeDescription = obs.OperationTypeDescription,
                StateRegistration = obs.StateRegistration,
                Name = obs.Name,
                Address = obs.Address,
                Mrh = obs.Mrh,
                City = obs.City,
                State = obs.State,
                Municipality = obs.Municipality,
                InvoiceText = obs.InvoiceText,
                FreeText = obs.FreeText
            };
        }

        private static OrderBlockDto MapOrderBlockToDto(OrderBlock block)
        {
            return new OrderBlockDto
            {
                OrderNumber = block.OrderNumber,
                LineNumber = block.LineNumber,
                SequentialId = block.SequentialId,
                BlockDescription = block.BlockDescription,
                Status = block.Status,
                StatusDate = block.StatusDate,
                Message = block.Message,
                BlockTypeId = block.BlockTypeId
            };
        }

        private static OrderInvoiceDto MapOrderInvoiceToDto(OrderInvoice invoice)
        {
            return new OrderInvoiceDto
            {
                InvoiceCode = invoice.InvoiceCode,
                Series = invoice.Series,
                OrderNumber = invoice.OrderNumber,
                ClientCode = invoice.ClientCode,
                Establishment = invoice.Establishment,
                FactoryCode = invoice.FactoryCode,
                StatusCode = invoice.StatusCode,
                InvoiceType = invoice.InvoiceType,
                EmissionDate = invoice.EmissionDate,
                MerchandiseExitDate = invoice.MerchandiseExitDate,
                IcmsBaseValue = invoice.IcmsBaseValue,
                IcmsValue = invoice.IcmsValue,
                IpiValue = invoice.IpiValue,
                IcmsAliquotValue = invoice.IcmsAliquotValue,
                NetWeight = invoice.NetWeight,
                GrossWeight = invoice.GrossWeight,
                DiscountValue = invoice.DiscountValue,
                TotalValue = invoice.TotalValue,
                TotalInvoicedUnits = invoice.TotalInvoicedUnits,
                VolumeQuantity = invoice.VolumeQuantity,
                TransportWay = invoice.TransportWay,
                TransportDescription = invoice.TransportDescription,
                AdditionalDiscountValue = invoice.AdditionalDiscountValue,
                QualityDescription = invoice.QualityDescription,
                CurrencyCode = invoice.CurrencyCode,
                FactoryDescription = invoice.FactoryDescription,
                ClientCnpj = invoice.ClientCnpj,
                ClientRazaoSocial = invoice.ClientRazaoSocial,
                ClientTradeName = invoice.ClientTradeName,
                TransportCode = invoice.TransportCode
            };
        }

        #endregion
    }
}