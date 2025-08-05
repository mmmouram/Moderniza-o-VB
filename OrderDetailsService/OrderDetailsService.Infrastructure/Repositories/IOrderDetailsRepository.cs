using System.Collections.Generic;
using System.Threading.Tasks;
using OrderDetailsService.Domain.Entities;

namespace OrderDetailsService.Infrastructure.Repositories
{
    /// <summary>
    /// Repository interface for accessing all data required by the modernized Order Details form,
    /// including order details, items, observations, blocks, invoices, and persisted UI state.
    /// </summary>
    public interface IOrderDetailsRepository
    {
        /// <summary>
        /// Retrieves the order and all related details (client info, items, observations, blocks, invoices, persisted state) for a specific order number.
        /// </summary>
        /// <param name="orderNumber">The unique order number.</param>
        /// <returns>The order entity with all related data, or null if not found.</returns>
        Task<Order> GetOrderWithDetailsAsync(string orderNumber);

        /// <summary>
        /// Retrieves the list of items for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The list of order items.</returns>
        Task<List<OrderItem>> GetOrderItemsAsync(string orderNumber);

        /// <summary>
        /// Retrieves the list of observations for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The list of order observations.</returns>
        Task<List<OrderObservation>> GetOrderObservationsAsync(string orderNumber);

        /// <summary>
        /// Retrieves the list of blocks (restrictions) for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The list of order blocks.</returns>
        Task<List<OrderBlock>> GetOrderBlocksAsync(string orderNumber);

        /// <summary>
        /// Retrieves the list of invoices (notas fiscais) for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The list of order invoices.</returns>
        Task<List<OrderInvoice>> GetOrderInvoicesAsync(string orderNumber);

        /// <summary>
        /// Persists the state of list view positions and checkbox values for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="state">The state persistence entity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task PersistStateAsync(string orderNumber, OrderDetailStatePersistence state);

        /// <summary>
        /// Retrieves the persisted state of list view positions and checkbox values for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The persisted state entity, or null if not found.</returns>
        Task<OrderDetailStatePersistence> GetPersistedStateAsync(string orderNumber);
    }
}