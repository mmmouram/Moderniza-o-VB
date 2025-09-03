using System;
using System.Collections.Generic;

namespace OrderDetailsService.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for the Order Details form, supporting all required business rules for the modernized order detail view.
    /// </summary>
    public class OrderDetailsDto
    {
        /// <summary>
        /// Order number (unique identifier).
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// CNPJ of the client.
        /// </summary>
        public string ClientCnpj { get; set; }

        /// <summary>
        /// Razão Social (legal name) of the client.
        /// </summary>
        public string ClientRazaoSocial { get; set; }

        /// <summary>
        /// Date when the order was included.
        /// </summary>
        public DateTime? InclusionDate { get; set; }

        /// <summary>
        /// Establishment code.
        /// </summary>
        public string Establishment { get; set; }

        /// <summary>
        /// Client code.
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// Transport description.
        /// </summary>
        public string TransportDescription { get; set; }

        /// <summary>
        /// Last update date.
        /// </summary>
        public DateTime? LastUpdateDate { get; set; }

        /// <summary>
        /// Client's order number.
        /// </summary>
        public string ClientOrderNumber { get; set; }

        /// <summary>
        /// Post code.
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// Total value of the order.
        /// </summary>
        public decimal? TotalOrderValue { get; set; }

        /// <summary>
        /// Commercial condition description.
        /// </summary>
        public string CommercialConditionDescription { get; set; }

        /// <summary>
        /// Billing status description.
        /// </summary>
        public string BillingStatusDescription { get; set; }

        /// <summary>
        /// Order status code.
        /// </summary>
        public string OrderStatusCode { get; set; }

        /// <summary>
        /// Order status description.
        /// </summary>
        public string OrderStatusDescription { get; set; }

        /// <summary>
        /// Required date for the order.
        /// </summary>
        public DateTime? RequiredDate { get; set; }

        /// <summary>
        /// List of items in the order (for the "Itens do Pedido" tab).
        /// </summary>
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();

        /// <summary>
        /// List of observations for the order (for the "Observações" tab).
        /// </summary>
        public List<OrderObservationDto> Observations { get; set; } = new List<OrderObservationDto>();

        /// <summary>
        /// List of blocks (restrictions) for the order (for the "Bloqueios de Pedido" tab).
        /// </summary>
        public List<OrderBlockDto> Blocks { get; set; } = new List<OrderBlockDto>();

        /// <summary>
        /// List of invoices (notas fiscais) related to the order (for the "Nota Fiscal" tab).
        /// </summary>
        public List<OrderInvoiceDto> Invoices { get; set; } = new List<OrderInvoiceDto>();

        /// <summary>
        /// Indicates if the items list should be auto-loaded.
        /// </summary>
        public bool AutoLoadItems { get; set; }

        /// <summary>
        /// Indicates if the observations list should be auto-loaded.
        /// </summary>
        public bool AutoLoadObservations { get; set; }

        /// <summary>
        /// Indicates if the blocks list should be auto-loaded.
        /// </summary>
        public bool AutoLoadBlocks { get; set; }

        /// <summary>
        /// Indicates if the invoices list should be auto-loaded.
        /// </summary>
        public bool AutoLoadInvoices { get; set; }

        /// <summary>
        /// Stores persisted state for list view positions and checkboxes.
        /// </summary>
        public OrderDetailStatePersistenceDto StatePersistence { get; set; } = new OrderDetailStatePersistenceDto();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OrderDetailsDto() { }
    }

    /// <summary>
    /// DTO for persisting state and positions of controls (list views, checkboxes, etc.).
    /// </summary>
    public class OrderDetailStatePersistenceDto
    {
        /// <summary>
        /// Stores the selected index or key for the items list.
        /// </summary>
        public string ItemsListSelectedKey { get; set; }

        /// <summary>
        /// Stores the selected index or key for the observations list.
        /// </summary>
        public string ObservationsListSelectedKey { get; set; }

        /// <summary>
        /// Stores the selected index or key for the blocks list.
        /// </summary>
        public string BlocksListSelectedKey { get; set; }

        /// <summary>
        /// Stores the selected index or key for the invoices list.
        /// </summary>
        public string InvoicesListSelectedKey { get; set; }

        /// <summary>
        /// Stores the persisted value for the auto-load items checkbox.
        /// </summary>
        public bool AutoLoadItemsChecked { get; set; }

        /// <summary>
        /// Stores the persisted value for the auto-load observations checkbox.
        /// </summary>
        public bool AutoLoadObservationsChecked { get; set; }

        /// <summary>
        /// Stores the persisted value for the auto-load blocks checkbox.
        /// </summary>
        public bool AutoLoadBlocksChecked { get; set; }

        /// <summary>
        /// Stores the persisted value for the auto-load invoices checkbox.
        /// </summary>
        public bool AutoLoadInvoicesChecked { get; set; }
    }

    /// <summary>
    /// DTO for the response of exporting order data to SAP.
    /// </summary>
    public class ExportToSapResponse
    {
        /// <summary>
        /// Indicates if the export was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Optional message with details about the export operation.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Optional SAP document number or identifier, if available.
        /// </summary>
        public string SapDocumentNumber { get; set; }
    }
}