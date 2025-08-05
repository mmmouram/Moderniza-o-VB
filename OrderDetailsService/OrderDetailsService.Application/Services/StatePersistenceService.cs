using System;
using System.Threading.Tasks;
using OrderDetailsService.Application.DTOs;
using OrderDetailsService.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace OrderDetailsService.Application.Services
{
    /// <summary>
    /// Service responsible for persisting and retrieving the state of list view positions and checkbox values
    /// for the order detail form, ensuring consistency of user preferences and UI state between sessions.
    /// </summary>
    public class StatePersistenceService : IStatePersistenceService
    {
        private readonly IMemoryCache _memoryCache;
        private static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromDays(7);

        public StatePersistenceService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <inheritdoc />
        public Task PersistStateAsync(string orderNumber, OrderDetailStatePersistenceDto state)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("Order number must be provided.", nameof(orderNumber));

            if (state == null)
                throw new ArgumentNullException(nameof(state));

            var cacheKey = GetCacheKey(orderNumber);
            _memoryCache.Set(cacheKey, state, DefaultCacheDuration);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<OrderDetailStatePersistenceDto> GetPersistedStateAsync(string orderNumber)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("Order number must be provided.", nameof(orderNumber));

            var cacheKey = GetCacheKey(orderNumber);
            if (_memoryCache.TryGetValue<OrderDetailStatePersistenceDto>(cacheKey, out var state))
            {
                return Task.FromResult(state);
            }

            // Return a new instance if not found (default state)
            return Task.FromResult(new OrderDetailStatePersistenceDto());
        }

        private static string GetCacheKey(string orderNumber)
        {
            // In a real-world scenario, this could include user/session info for multi-user isolation
            return $"OrderDetailState:{orderNumber}";
        }
    }
}