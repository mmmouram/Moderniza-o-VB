using System;

namespace OrderDetailsService.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object representing an invoice (Nota Fiscal) associated with an order,
    /// as shown in the "Nota Fiscal" tab of the order detail form.
    /// </summary>
    public class OrderInvoiceDto
    {
        /// <summary>
        /// Invoice code (COD_NOTA_FISCAL).
        /// </summary>
        public string InvoiceCode { get; set; }

        /// <summary>
        /// Invoice series (SERIE).
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Order number (NUM_PEDIDO) associated with this invoice.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Client code (CLIENTE).
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// Establishment code (ESTABELECIMENTO).
        /// </summary>
        public string Establishment { get; set; }

        /// <summary>
        /// Factory code (COD_FABRICA).
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// Invoice status code (STATUS_NF).
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Invoice type (TIPO_NF).
        /// </summary>
        public string InvoiceType { get; set; }

        /// <summary>
        /// Invoice emission date (DATA_EMISSAO).
        /// </summary>
        public DateTime? EmissionDate { get; set; }

        /// <summary>
        /// Merchandise exit date (DATA_SAIDA_MER).
        /// </summary>
        public DateTime? MerchandiseExitDate { get; set; }

        /// <summary>
        /// ICMS base value (VALOR_BCICM).
        /// </summary>
        public decimal? IcmsBaseValue { get; set; }

        /// <summary>
        /// ICMS value (VALOR_ICM).
        /// </summary>
        public decimal? IcmsValue { get; set; }

        /// <summary>
        /// IPI value (VALOR_IPI).
        /// </summary>
        public decimal? IpiValue { get; set; }

        /// <summary>
        /// ICMS aliquot value (VALOR_ALIQICM).
        /// </summary>
        public decimal? IcmsAliquotValue { get; set; }

        /// <summary>
        /// Net weight (PESO_LIQ).
        /// </summary>
        public decimal? NetWeight { get; set; }

        /// <summary>
        /// Gross weight (PESO_BRUTO).
        /// </summary>
        public decimal? GrossWeight { get; set; }

        /// <summary>
        /// Discount value (VALOR_DESC).
        /// </summary>
        public decimal? DiscountValue { get; set; }

        /// <summary>
        /// Total value (VALOR_TOTAL).
        /// </summary>
        public decimal? TotalValue { get; set; }

        /// <summary>
        /// Total invoiced units (TOTAL_UNID_FATUR).
        /// </summary>
        public decimal? TotalInvoicedUnits { get; set; }

        /// <summary>
        /// Volume quantity (QTD_VOLUME).
        /// </summary>
        public decimal? VolumeQuantity { get; set; }

        /// <summary>
        /// Transport way (VIA_TRANSPORTE).
        /// </summary>
        public string TransportWay { get; set; }

        /// <summary>
        /// Transport description (DES_TRANSPORTE).
        /// </summary>
        public string TransportDescription { get; set; }

        /// <summary>
        /// Additional discount value (VALOR_DESC_PONT).
        /// </summary>
        public decimal? AdditionalDiscountValue { get; set; }

        /// <summary>
        /// Quality description (DES_QUALIDADE).
        /// </summary>
        public string QualityDescription { get; set; }

        /// <summary>
        /// Currency code (CODMOEDA).
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Factory description (DES_FABRICA).
        /// </summary>
        public string FactoryDescription { get; set; }

        /// <summary>
        /// CNPJ of the client.
        /// </summary>
        public string ClientCnpj { get; set; }

        /// <summary>
        /// Razão Social (legal name) of the client.
        /// </summary>
        public string ClientRazaoSocial { get; set; }

        /// <summary>
        /// Client's trade name (NOME_FANTASIA).
        /// </summary>
        public string ClientTradeName { get; set; }

        /// <summary>
        /// Transport code (COD_TRANSP).
        /// </summary>
        public string TransportCode { get; set; }

        /// <summary>
        /// Returns a user-friendly status description for the invoice.
        /// </summary>
        public string StatusDescription
        {
            get
            {
                return StatusCode switch
                {
                    "A" => "Contabilizado",
                    "C" => "Encerrado",
                    "E" => "Editado",
                    "H" => "Suspenso",
                    "O" => "Aberto",
                    "V" => "Transf.Voucher",
                    "X" => "Excluido",
                    _ => StatusCode
                };
            }
        }

        /// <summary>
        /// Returns a sortable emission date string (yyyyMMdd) for ordering purposes.
        /// </summary>
        public string SortableEmissionDate
        {
            get
            {
                return EmissionDate.HasValue ? EmissionDate.Value.ToString("yyyyMMdd") : string.Empty;
            }
        }

        /// <summary>
        /// Returns a sortable merchandise exit date string (yyyyMMdd) for ordering purposes.
        /// </summary>
        public string SortableMerchandiseExitDate
        {
            get
            {
                return MerchandiseExitDate.HasValue ? MerchandiseExitDate.Value.ToString("yyyyMMdd") : string.Empty;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OrderInvoiceDto() { }
    }
}