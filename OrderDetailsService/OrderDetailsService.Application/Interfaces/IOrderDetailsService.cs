using System.Threading.Tasks;
using OrderDetailsService.Application.DTOs;

namespace OrderDetailsService.Application.Interfaces
{
    /// <summary>
    /// Service interface for handling all business logic related to the modernized Order Details form,
    /// including retrieval, update, export, and state persistence for order details, items, observations, blocks, and invoices.
    /// </summary>
    public interface IOrderDetailsService
    {
        /// <summary>
        /// Retrieves all details for a specific order, including client info, items, observations, blocks, invoices,
        /// and persisted state for list positions and checkboxes.
        /// </summary>
        /// <param name="orderNumber">The unique order number to retrieve details for.</param>
        /// <returns>A DTO containing all order details and related lists.</returns>
        Task<OrderDetailsDto> GetOrderDetailsAsync(string orderNumber);

        /// <summary>
        /// Updates and returns the latest list of items for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The updated list of order items.</returns>
        Task<OrderItemDto[]> UpdateOrderItemsAsync(string orderNumber);

        /// <summary>
        /// Updates and returns the latest list of observations for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The updated list of order observations.</returns>
        Task<OrderObservationDto[]> UpdateOrderObservationsAsync(string orderNumber);

        /// <summary>
        /// Updates and returns the latest list of blocks for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The updated list of order blocks.</returns>
        Task<OrderBlockDto[]> UpdateOrderBlocksAsync(string orderNumber);

        /// <summary>
        /// Updates and returns the latest list of invoices for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The updated list of order invoices.</returns>
        Task<OrderInvoiceDto[]> UpdateOrderInvoicesAsync(string orderNumber);

        /// <summary>
        /// Exports the specified list type (items, observations, blocks, invoices) for a given order to an Excel file.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="listType">The type of list to export ("items", "observations", "blocks", "invoices").</param>
        /// <returns>The Excel file as a byte array.</returns>
        Task<byte[]> ExportListToExcelAsync(string orderNumber, string listType);

        /// <summary>
        /// Persists the state of list view positions and checkbox values for a given order and user/session.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="state">The state persistence DTO containing positions and checkbox values.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task PersistStateAsync(string orderNumber, OrderDetailStatePersistenceDto state);

        /// <summary>
        /// Retrieves the persisted state of list view positions and checkbox values for a given order and user/session.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The persisted state DTO.</returns>
        Task<OrderDetailStatePersistenceDto> GetPersistedStateAsync(string orderNumber);
    }
}