using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderDetailsService.Application.DTOs;
using OrderDetailsService.Application.Interfaces;

namespace OrderDetailsService.API.Controllers
{
    /// <summary>
    /// API Controller for the modernized Order Details form.
    /// Handles retrieval, update, export, and state persistence for order details, items, observations, blocks, and invoices.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly ILogger<OrderDetailsController> _logger;

        public OrderDetailsController(
            IOrderDetailsService orderDetailsService,
            ILogger<OrderDetailsController> logger)
        {
            _orderDetailsService = orderDetailsService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all details for a specific order, including client info, items, observations, blocks, invoices,
        /// and persisted state for list positions and checkboxes.
        /// </summary>
        /// <param name="orderNumber">The unique order number to retrieve details for.</param>
        /// <returns>A DTO containing all order details and related lists.</returns>
        [HttpGet("{orderNumber}")]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderDetails(string orderNumber)
        {
            var dto = await _orderDetailsService.GetOrderDetailsAsync(orderNumber);
            return Ok(dto);
        }

        /// <summary>
        /// Updates and returns the latest list of items for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The updated list of order items.</returns>
        [HttpGet("{orderNumber}/items")]
        public async Task<ActionResult<OrderItemDto[]>> UpdateOrderItems(string orderNumber)
        {
            var items = await _orderDetailsService.UpdateOrderItemsAsync(orderNumber);
            return Ok(items);
        }

        /// <summary>
        /// Updates and returns the latest list of observations for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The updated list of order observations.</returns>
        [HttpGet("{orderNumber}/observations")]
        public async Task<ActionResult<OrderObservationDto[]>> UpdateOrderObservations(string orderNumber)
        {
            var observations = await _orderDetailsService.UpdateOrderObservationsAsync(orderNumber);
            return Ok(observations);
        }

        /// <summary>
        /// Updates and returns the latest list of blocks for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The updated list of order blocks.</returns>
        [HttpGet("{orderNumber}/blocks")]
        public async Task<ActionResult<OrderBlockDto[]>> UpdateOrderBlocks(string orderNumber)
        {
            var blocks = await _orderDetailsService.UpdateOrderBlocksAsync(orderNumber);
            return Ok(blocks);
        }

        /// <summary>
        /// Updates and returns the latest list of invoices for a given order.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The updated list of order invoices.</returns>
        [HttpGet("{orderNumber}/invoices")]
        public async Task<ActionResult<OrderInvoiceDto[]>> UpdateOrderInvoices(string orderNumber)
        {
            var invoices = await _orderDetailsService.UpdateOrderInvoicesAsync(orderNumber);
            return Ok(invoices);
        }

        /// <summary>
        /// Exports the specified list type (items, observations, blocks, invoices) for a given order to an Excel file.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="listType">The type of list to export ("items", "observations", "blocks", "invoices").</param>
        /// <returns>The Excel file as a byte array.</returns>
        [HttpGet("{orderNumber}/export/{listType}")]
        public async Task<IActionResult> ExportListToExcel(string orderNumber, string listType)
        {
            var fileBytes = await _orderDetailsService.ExportListToExcelAsync(orderNumber, listType);
            var fileName = $"Pedido_{orderNumber}_{listType}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            return File(fileBytes, MediaTypeNames.Application.Octet, fileName);
        }

        /// <summary>
        /// Persists the state of list view positions and checkbox values for a given order and user/session.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="state">The state persistence DTO containing positions and checkbox values.</param>
        [HttpPost("{orderNumber}/state")]
        public async Task<IActionResult> PersistState(string orderNumber, [FromBody] OrderDetailStatePersistenceDto state)
        {
            await _orderDetailsService.PersistStateAsync(orderNumber, state);
            return NoContent();
        }

        /// <summary>
        /// Retrieves the persisted state of list view positions and checkbox values for a given order and user/session.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>The persisted state DTO.</returns>
        [HttpGet("{orderNumber}/state")]
        public async Task<ActionResult<OrderDetailStatePersistenceDto>> GetPersistedState(string orderNumber)
        {
            var state = await _orderDetailsService.GetPersistedStateAsync(orderNumber);
            return Ok(state);
        }

        /// <summary>
        /// Exports the order data to SAP.
        /// </summary>
        /// <param name="orderNumber">The order number to export.</param>
        /// <returns>Response DTO with export result and SAP document number if available.</returns>
        [HttpPost("{orderNumber}/export-to-sap")]
        public async Task<ActionResult<ExportToSapResponse>> ExportToSap(string orderNumber)
        {
            var response = await _orderDetailsService.ExportToSapAsync(orderNumber);
            return Ok(response);
        }
    }
}