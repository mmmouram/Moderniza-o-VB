using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderDetailsService.Domain.Entities;
using OrderDetailsService.Infrastructure.Data;

namespace OrderDetailsService.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for accessing all data required by the modernized Order Details form,
    /// including order details, items, observations, blocks, invoices, and persisted UI state.
    /// </summary>
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly OrderDetailsDbContext _dbContext;

        public OrderDetailsRepository(OrderDetailsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<Order> GetOrderWithDetailsAsync(string orderNumber)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                return null;

            // Load order and all related data
            var order = await _dbContext.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderNumber == orderNumber);

            if (order == null)
                return null;

            // Load related lists
            order.Items = await _dbContext.OrderItems
                .AsNoTracking()
                .Where(i => i.OrderNumber == orderNumber)
                .OrderBy(i => i.SequentialId)
                .ToListAsync();

            order.Observations = await _dbContext.OrderObservations
                .AsNoTracking()
                .Where(o => o.OrderNumber == orderNumber)
                .OrderBy(o => o.SequentialId)
                .ToListAsync();

            order.Blocks = await _dbContext.OrderBlocks
                .AsNoTracking()
                .Where(b => b.OrderNumber == orderNumber)
                .OrderBy(b => b.SequentialId)
                .ToListAsync();

            order.Invoices = await _dbContext.OrderInvoices
                .AsNoTracking()
                .Where(i => i.OrderNumber == orderNumber)
                .OrderBy(i => i.InvoiceCode)
                .ThenBy(i => i.Series)
                .ToListAsync();

            // Load persisted state (if exists)
            var state = await _dbContext.OrderDetailStatePersistences
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.OrderNumber == orderNumber);

            if (state != null)
            {
                order.StatePersistence = state;
            }

            return order;
        }

        /// <inheritdoc />
        public async Task<List<OrderItem>> GetOrderItemsAsync(string orderNumber)
        {
            return await _dbContext.OrderItems
                .AsNoTracking()
                .Where(i => i.OrderNumber == orderNumber)
                .OrderBy(i => i.SequentialId)
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<List<OrderObservation>> GetOrderObservationsAsync(string orderNumber)
        {
            return await _dbContext.OrderObservations
                .AsNoTracking()
                .Where(o => o.OrderNumber == orderNumber)
                .OrderBy(o => o.SequentialId)
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<List<OrderBlock>> GetOrderBlocksAsync(string orderNumber)
        {
            return await _dbContext.OrderBlocks
                .AsNoTracking()
                .Where(b => b.OrderNumber == orderNumber)
                .OrderBy(b => b.SequentialId)
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<List<OrderInvoice>> GetOrderInvoicesAsync(string orderNumber)
        {
            return await _dbContext.OrderInvoices
                .AsNoTracking()
                .Where(i => i.OrderNumber == orderNumber)
                .OrderBy(i => i.InvoiceCode)
                .ThenBy(i => i.Series)
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task PersistStateAsync(string orderNumber, OrderDetailStatePersistence state)
        {
            if (string.IsNullOrWhiteSpace(orderNumber) || state == null)
                return;

            var existing = await _dbContext.OrderDetailStatePersistences
                .FirstOrDefaultAsync(s => s.OrderNumber == orderNumber);

            if (existing == null)
            {
                state.OrderNumber = orderNumber;
                _dbContext.OrderDetailStatePersistences.Add(state);
            }
            else
            {
                existing.ItemsListSelectedKey = state.ItemsListSelectedKey;
                existing.ObservationsListSelectedKey = state.ObservationsListSelectedKey;
                existing.BlocksListSelectedKey = state.BlocksListSelectedKey;
                existing.InvoicesListSelectedKey = state.InvoicesListSelectedKey;
                existing.AutoLoadItemsChecked = state.AutoLoadItemsChecked;
                existing.AutoLoadObservationsChecked = state.AutoLoadObservationsChecked;
                existing.AutoLoadBlocksChecked = state.AutoLoadBlocksChecked;
                existing.AutoLoadInvoicesChecked = state.AutoLoadInvoicesChecked;
                _dbContext.OrderDetailStatePersistences.Update(existing);
            }

            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<OrderDetailStatePersistence> GetPersistedStateAsync(string orderNumber)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                return null;

            return await _dbContext.OrderDetailStatePersistences
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.OrderNumber == orderNumber);
        }
    }
}