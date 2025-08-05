using Microsoft.EntityFrameworkCore;
using OrderDetailsService.Domain.Entities;

namespace OrderDetailsService.Infrastructure.Data
{
    /// <summary>
    /// Entity Framework Core DbContext for the Order Details Service.
    /// This context manages all entities required for the modernized order detail form,
    /// including orders, items, observations, blocks, invoices, and persisted UI state.
    /// </summary>
    public class OrderDetailsDbContext : DbContext
    {
        public OrderDetailsDbContext(DbContextOptions<OrderDetailsDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Orders with all details (client info, items, observations, blocks, invoices, persisted state).
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Items belonging to orders.
        /// </summary>
        public DbSet<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Observations associated with orders.
        /// </summary>
        public DbSet<OrderObservation> OrderObservations { get; set; }

        /// <summary>
        /// Blocks (restrictions) applied to orders.
        /// </summary>
        public DbSet<OrderBlock> OrderBlocks { get; set; }

        /// <summary>
        /// Invoices (Notas Fiscais) related to orders.
        /// </summary>
        public DbSet<OrderInvoice> OrderInvoices { get; set; }

        /// <summary>
        /// Persisted state for list view positions and checkbox values.
        /// </summary>
        public DbSet<OrderDetailStatePersistence> OrderDetailStatePersistences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Order
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderNumber);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderNumber)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Order>()
                .Property(o => o.ClientCnpj)
                .HasMaxLength(32);

            modelBuilder.Entity<Order>()
                .Property(o => o.ClientRazaoSocial)
                .HasMaxLength(128);

            // OrderItem
            modelBuilder.Entity<OrderItem>()
                .HasKey(i => new { i.OrderNumber, i.SequentialId });

            modelBuilder.Entity<OrderItem>()
                .Property(i => i.OrderNumber)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<OrderItem>()
                .Property(i => i.ProductCode)
                .HasMaxLength(32);

            // OrderObservation
            modelBuilder.Entity<OrderObservation>()
                .HasKey(o => new { o.OrderNumber, o.SequentialId });

            modelBuilder.Entity<OrderObservation>()
                .Property(o => o.OrderNumber)
                .IsRequired()
                .HasMaxLength(32);

            // OrderBlock
            modelBuilder.Entity<OrderBlock>()
                .HasKey(b => new { b.OrderNumber, b.SequentialId });

            modelBuilder.Entity<OrderBlock>()
                .Property(b => b.OrderNumber)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<OrderBlock>()
                .Property(b => b.LineNumber)
                .HasMaxLength(16);

            modelBuilder.Entity<OrderBlock>()
                .Property(b => b.BlockDescription)
                .HasMaxLength(128);

            modelBuilder.Entity<OrderBlock>()
                .Property(b => b.Status)
                .HasMaxLength(2);

            modelBuilder.Entity<OrderBlock>()
                .Property(b => b.Message)
                .HasMaxLength(256);

            modelBuilder.Entity<OrderBlock>()
                .Property(b => b.BlockTypeId)
                .HasMaxLength(2);

            // OrderInvoice
            modelBuilder.Entity<OrderInvoice>()
                .HasKey(i => new { i.InvoiceCode, i.Series });

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.InvoiceCode)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.Series)
                .IsRequired()
                .HasMaxLength(16);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.OrderNumber)
                .HasMaxLength(32);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.ClientCode)
                .HasMaxLength(32);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.Establishment)
                .HasMaxLength(32);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.FactoryCode)
                .HasMaxLength(32);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.StatusCode)
                .HasMaxLength(2);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.InvoiceType)
                .HasMaxLength(8);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.TransportWay)
                .HasMaxLength(32);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.TransportDescription)
                .HasMaxLength(128);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.QualityDescription)
                .HasMaxLength(64);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.CurrencyCode)
                .HasMaxLength(8);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.FactoryDescription)
                .HasMaxLength(64);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.ClientCnpj)
                .HasMaxLength(32);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.ClientRazaoSocial)
                .HasMaxLength(128);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.ClientTradeName)
                .HasMaxLength(128);

            modelBuilder.Entity<OrderInvoice>()
                .Property(i => i.TransportCode)
                .HasMaxLength(32);

            // OrderDetailStatePersistence
            modelBuilder.Entity<OrderDetailStatePersistence>()
                .HasKey(s => s.OrderNumber);

            modelBuilder.Entity<OrderDetailStatePersistence>()
                .Property(s => s.OrderNumber)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<OrderDetailStatePersistence>()
                .Property(s => s.ItemsListSelectedKey)
                .HasMaxLength(64);

            modelBuilder.Entity<OrderDetailStatePersistence>()
                .Property(s => s.ObservationsListSelectedKey)
                .HasMaxLength(64);

            modelBuilder.Entity<OrderDetailStatePersistence>()
                .Property(s => s.BlocksListSelectedKey)
                .HasMaxLength(64);

            modelBuilder.Entity<OrderDetailStatePersistence>()
                .Property(s => s.InvoicesListSelectedKey)
                .HasMaxLength(64);

            // Relationships (if needed, e.g., navigation properties)
            // In this context, navigation properties are not required for the business rule,
            // as the service layer handles aggregation and mapping.
        }
    }
}