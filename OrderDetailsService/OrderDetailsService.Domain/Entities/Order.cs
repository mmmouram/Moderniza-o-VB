using System;
using System.Collections.Generic;

namespace OrderDetailsService.Domain.Entities
{
    /// <summary>
    /// Represents an Order with all details for the order detail form.
    /// </summary>
    public class Order
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
        /// List of items in the order.
        /// </summary>
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        /// <summary>
        /// List of observations for the order.
        /// </summary>
        public List<OrderObservation> Observations { get; set; } = new List<OrderObservation>();

        /// <summary>
        /// List of blocks (restrictions) for the order.
        /// </summary>
        public List<OrderBlock> Blocks { get; set; } = new List<OrderBlock>();

        /// <summary>
        /// List of invoices (notas fiscais) related to the order.
        /// </summary>
        public List<OrderInvoice> Invoices { get; set; } = new List<OrderInvoice>();

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
        public OrderDetailStatePersistence StatePersistence { get; set; } = new OrderDetailStatePersistence();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Order() { }
    }
}