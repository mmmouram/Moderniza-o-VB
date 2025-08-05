using System.Threading.Tasks;

namespace OrderDetailsService.Application.Interfaces
{
    /// <summary>
    /// Service interface for exporting order-related lists (items, observations, blocks, invoices) to Excel files.
    /// </summary>
    public interface IExcelExportService
    {
        /// <summary>
        /// Exports the specified list type (items, observations, blocks, invoices) for a given order to an Excel file.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="listType">The type of list to export ("items", "observations", "blocks", "invoices").</param>
        /// <returns>The Excel file as a byte array.</returns>
        Task<byte[]> ExportListToExcelAsync(string orderNumber, string listType);
    }
}