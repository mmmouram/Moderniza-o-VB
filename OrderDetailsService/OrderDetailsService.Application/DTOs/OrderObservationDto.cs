using System;

namespace OrderDetailsService.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object representing an observation (observação) associated with an order,
    /// as shown in the "Observações" tab of the order detail form.
    /// </summary>
    public class OrderObservationDto
    {
        /// <summary>
        /// Order number to which this observation belongs.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Sequential identifier for the observation (ID_SEQUENCIAL).
        /// </summary>
        public int SequentialId { get; set; }

        /// <summary>
        /// Description of the operation type (DES_TIPO_OPERACAO).
        /// </summary>
        public string OperationTypeDescription { get; set; }

        /// <summary>
        /// State registration of the client (INSCRICAO_ESTADUAL).
        /// </summary>
        public string StateRegistration { get; set; }

        /// <summary>
        /// Name (NOME) associated with the observation (e.g., client name).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address (ENDERECO) associated with the observation.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// MRH field (MRH) - legacy field, may represent a code or additional info.
        /// </summary>
        public string Mrh { get; set; }

        /// <summary>
        /// City (CIDADE) associated with the observation.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State (UF) associated with the observation.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Municipality (MUNICIPIO) associated with the observation.
        /// </summary>
        public string Municipality { get; set; }

        /// <summary>
        /// Text for Nota Fiscal (TEXTO_NOTA_FISCAL).
        /// </summary>
        public string InvoiceText { get; set; }

        /// <summary>
        /// Free text (TEXTO_LIVRE) for additional notes.
        /// </summary>
        public string FreeText { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OrderObservationDto() { }
    }
}