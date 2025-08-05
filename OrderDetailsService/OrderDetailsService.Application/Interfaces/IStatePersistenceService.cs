using System.Threading.Tasks;
using OrderDetailsService.Application.DTOs;

namespace OrderDetailsService.Application.Interfaces
{
    /// <summary>
    /// Service interface for persisting and retrieving the state of list view positions and checkbox values
    /// for the order detail form, ensuring consistency of user preferences and UI state between sessions.
    /// </summary>
    public interface IStatePersistenceService
    {
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