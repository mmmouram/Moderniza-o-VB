using System;

namespace OrderDetailsService.API.Models
{
    /// <summary>
    /// Response DTO for exporting order data to SAP.
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