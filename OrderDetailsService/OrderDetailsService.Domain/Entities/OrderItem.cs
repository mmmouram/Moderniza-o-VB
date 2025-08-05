using System;

namespace OrderDetailsService.Domain.Entities
{
    /// <summary>
    /// Represents an item within an order, as shown in the "Itens do Pedido" tab of the order detail form.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Order number to which this item belongs.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Product code (COD_PRODUTO).
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Sequential identifier for the item (ID_SEQUENCIAL).
        /// </summary>
        public int SequentialId { get; set; }

        /// <summary>
        /// Ordered quantity (QTD_PEDIDA).
        /// </summary>
        public decimal? OrderedQuantity { get; set; }

        /// <summary>
        /// Invoiced quantity (QTD_FATURADA).
        /// </summary>
        public decimal? InvoicedQuantity { get; set; }

        /// <summary>
        /// Destined quantity (QTD_DESTINADA).
        /// </summary>
        public decimal? DestinedQuantity { get; set; }

        /// <summary>
        /// Committed quantity (QTD_EMPENHADA).
        /// </summary>
        public decimal? CommittedQuantity { get; set; }

        /// <summary>
        /// Item status (SITUACAO).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Price value (VLR_PRECO).
        /// </summary>
        public decimal? PriceValue { get; set; }

        /// <summary>
        /// Balance value (VLR_SALDO).
        /// </summary>
        public decimal? BalanceValue { get; set; }

        /// <summary>
        /// Unit value (VLR_UNITARIO).
        /// </summary>
        public decimal? UnitValue { get; set; }

        /// <summary>
        /// Discount value (DESCONTO).
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// Payment condition (COND_PAGTO).
        /// </summary>
        public string PaymentCondition { get; set; }

        /// <summary>
        /// Price table (TABELA_PRECO).
        /// </summary>
        public string PriceTable { get; set; }

        /// <summary>
        /// Fiscal group for pricing (GRP_FISCAL_PRC).
        /// </summary>
        public string FiscalGroupPricing { get; set; }

        /// <summary>
        /// Fiscal operation for pricing (OPER_FISCAL_PRC).
        /// </summary>
        public string FiscalOperationPricing { get; set; }

        /// <summary>
        /// Fiscal group for delivery (GRP_FISCAL_ENT).
        /// </summary>
        public string FiscalGroupDelivery { get; set; }

        /// <summary>
        /// Fiscal operation for delivery (OPER_FISCAL_ENT).
        /// </summary>
        public string FiscalOperationDelivery { get; set; }

        /// <summary>
        /// Early date (DATA_CEDO).
        /// </summary>
        public DateTime? EarlyDate { get; set; }

        /// <summary>
        /// Late date (DATA_TARDE).
        /// </summary>
        public DateTime? LateDate { get; set; }

        /// <summary>
        /// Base date (DATA_BASE).
        /// </summary>
        public DateTime? BaseDate { get; set; }

        /// <summary>
        /// Short product description (DES_PRODUTO_CURTA).
        /// </summary>
        public string ProductShortDescription { get; set; }

        /// <summary>
        /// Long product description (DES_PRODUTO_LONGA).
        /// </summary>
        public string ProductLongDescription { get; set; }

        /// <summary>
        /// Returns a sortable early date string (yyyyMMdd) for ordering purposes.
        /// </summary>
        public string SortableEarlyDate
        {
            get
            {
                return EarlyDate.HasValue ? EarlyDate.Value.ToString("yyyyMMdd") : string.Empty;
            }
        }

        /// <summary>
        /// Returns a sortable late date string (yyyyMMdd) for ordering purposes.
        /// </summary>
        public string SortableLateDate
        {
            get
            {
                return LateDate.HasValue ? LateDate.Value.ToString("yyyyMMdd") : string.Empty;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OrderItem() { }
    }
}