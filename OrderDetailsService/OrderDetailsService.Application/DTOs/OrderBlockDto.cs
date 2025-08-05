using System;

namespace OrderDetailsService.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object representing a block (restriction) applied to an order,
    /// as shown in the "Bloqueios de Pedido" tab of the order detail form.
    /// </summary>
    public class OrderBlockDto
    {
        /// <summary>
        /// Order number to which this block belongs.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Line number (if applicable) for the block.
        /// </summary>
        public string LineNumber { get; set; }

        /// <summary>
        /// Sequential identifier for the block entry.
        /// </summary>
        public int SequentialId { get; set; }

        /// <summary>
        /// Description of the block.
        /// </summary>
        public string BlockDescription { get; set; }

        /// <summary>
        /// Status of the block ("A" for active, "I" for inactive).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Date when the status was set.
        /// </summary>
        public DateTime? StatusDate { get; set; }

        /// <summary>
        /// Additional message or reason for the block.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Block type identifier (e.g., "A", "B", "C", etc.).
        /// </summary>
        public string BlockTypeId { get; set; }

        /// <summary>
        /// Returns a user-friendly description for the block type.
        /// </summary>
        public string BlockTypeDescription
        {
            get
            {
                return BlockTypeId switch
                {
                    "A" => "Alteração",
                    "B" => "Cobrança",
                    "C" => "Cliente",
                    "E" => "Frete",
                    "F" => "Configurador",
                    "G" => "Grupo Ordem",
                    "H" => "Entrega",
                    "K" => "S Comp Kit",
                    "L" => "Local Entrega",
                    "M" => "Margem Min / Max",
                    "N" => "Preço Min",
                    "O" => "Vlr.Max Venda",
                    "P" => "Produto",
                    "Q" => "Qtde Min / Max",
                    "R" => "Verif.Crédito",
                    "S" => "Venda",
                    "T" => "Cotas",
                    "U" => "Fech.Ciclo",
                    "V" => "Vendor HLD",
                    "X" => "Qtde Min/Max CO",
                    "Y" => "Tolerância.Zero",
                    "Z" => "Prazo Médio",
                    _ => BlockTypeId
                };
            }
        }

        /// <summary>
        /// Returns a user-friendly status description.
        /// </summary>
        public string StatusDescription
        {
            get
            {
                return Status == "A" ? "Ativo" : "Inativo";
            }
        }

        /// <summary>
        /// Returns a sortable date string (yyyyMMdd) for ordering purposes.
        /// </summary>
        public string SortableStatusDate
        {
            get
            {
                return StatusDate.HasValue ? StatusDate.Value.ToString("yyyyMMdd") : string.Empty;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OrderBlockDto() { }
    }
}