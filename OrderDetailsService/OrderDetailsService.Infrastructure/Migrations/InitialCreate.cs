using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderDetailsService.Infrastructure.Migrations
{
    /// <summary>
    /// Initial migration for the modernized Order Details form.
    /// Implements all tables and persisted state required for the new order detail experience.
    /// </summary>
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Orders table
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(maxLength: 32, nullable: false),
                    ClientCnpj = table.Column<string>(maxLength: 32, nullable: true),
                    ClientRazaoSocial = table.Column<string>(maxLength: 128, nullable: true),
                    InclusionDate = table.Column<DateTime>(nullable: true),
                    Establishment = table.Column<string>(maxLength: 32, nullable: true),
                    ClientCode = table.Column<string>(maxLength: 32, nullable: true),
                    TransportDescription = table.Column<string>(maxLength: 128, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    ClientOrderNumber = table.Column<string>(maxLength: 32, nullable: true),
                    Post = table.Column<string>(maxLength: 32, nullable: true),
                    TotalOrderValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CommercialConditionDescription = table.Column<string>(maxLength: 128, nullable: true),
                    BillingStatusDescription = table.Column<string>(maxLength: 64, nullable: true),
                    OrderStatusCode = table.Column<string>(maxLength: 8, nullable: true),
                    OrderStatusDescription = table.Column<string>(maxLength: 64, nullable: true),
                    RequiredDate = table.Column<DateTime>(nullable: true),
                    AutoLoadItems = table.Column<bool>(nullable: false, defaultValue: true),
                    AutoLoadObservations = table.Column<bool>(nullable: false, defaultValue: true),
                    AutoLoadBlocks = table.Column<bool>(nullable: false, defaultValue: true),
                    AutoLoadInvoices = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                });

            // OrderItems table
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(maxLength: 32, nullable: false),
                    SequentialId = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(maxLength: 32, nullable: true),
                    OrderedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoicedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DestinedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CommittedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(maxLength: 8, nullable: true),
                    PriceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BalanceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentCondition = table.Column<string>(maxLength: 32, nullable: true),
                    PriceTable = table.Column<string>(maxLength: 32, nullable: true),
                    FiscalGroupPricing = table.Column<string>(maxLength: 16, nullable: true),
                    FiscalOperationPricing = table.Column<string>(maxLength: 16, nullable: true),
                    FiscalGroupDelivery = table.Column<string>(maxLength: 16, nullable: true),
                    FiscalOperationDelivery = table.Column<string>(maxLength: 16, nullable: true),
                    EarlyDate = table.Column<DateTime>(nullable: true),
                    LateDate = table.Column<DateTime>(nullable: true),
                    BaseDate = table.Column<DateTime>(nullable: true),
                    ProductShortDescription = table.Column<string>(maxLength: 128, nullable: true),
                    ProductLongDescription = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderNumber, x.SequentialId });
                });

            // OrderObservations table
            migrationBuilder.CreateTable(
                name: "OrderObservations",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(maxLength: 32, nullable: false),
                    SequentialId = table.Column<int>(nullable: false),
                    OperationTypeDescription = table.Column<string>(maxLength: 64, nullable: true),
                    StateRegistration = table.Column<string>(maxLength: 32, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Address = table.Column<string>(maxLength: 128, nullable: true),
                    Mrh = table.Column<string>(maxLength: 32, nullable: true),
                    City = table.Column<string>(maxLength: 64, nullable: true),
                    State = table.Column<string>(maxLength: 8, nullable: true),
                    Municipality = table.Column<string>(maxLength: 64, nullable: true),
                    InvoiceText = table.Column<string>(maxLength: 256, nullable: true),
                    FreeText = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderObservations", x => new { x.OrderNumber, x.SequentialId });
                });

            // OrderBlocks table
            migrationBuilder.CreateTable(
                name: "OrderBlocks",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(maxLength: 32, nullable: false),
                    SequentialId = table.Column<int>(nullable: false),
                    LineNumber = table.Column<string>(maxLength: 16, nullable: true),
                    BlockDescription = table.Column<string>(maxLength: 128, nullable: true),
                    Status = table.Column<string>(maxLength: 2, nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    Message = table.Column<string>(maxLength: 256, nullable: true),
                    BlockTypeId = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBlocks", x => new { x.OrderNumber, x.SequentialId });
                });

            // OrderInvoices table
            migrationBuilder.CreateTable(
                name: "OrderInvoices",
                columns: table => new
                {
                    InvoiceCode = table.Column<string>(maxLength: 32, nullable: false),
                    Series = table.Column<string>(maxLength: 16, nullable: false),
                    OrderNumber = table.Column<string>(maxLength: 32, nullable: true),
                    ClientCode = table.Column<string>(maxLength: 32, nullable: true),
                    Establishment = table.Column<string>(maxLength: 32, nullable: true),
                    FactoryCode = table.Column<string>(maxLength: 32, nullable: true),
                    StatusCode = table.Column<string>(maxLength: 2, nullable: true),
                    InvoiceType = table.Column<string>(maxLength: 8, nullable: true),
                    EmissionDate = table.Column<DateTime>(nullable: true),
                    MerchandiseExitDate = table.Column<DateTime>(nullable: true),
                    IcmsBaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IcmsValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IpiValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IcmsAliquotValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalInvoicedUnits = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VolumeQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransportWay = table.Column<string>(maxLength: 32, nullable: true),
                    TransportDescription = table.Column<string>(maxLength: 128, nullable: true),
                    AdditionalDiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QualityDescription = table.Column<string>(maxLength: 64, nullable: true),
                    CurrencyCode = table.Column<string>(maxLength: 8, nullable: true),
                    FactoryDescription = table.Column<string>(maxLength: 64, nullable: true),
                    ClientCnpj = table.Column<string>(maxLength: 32, nullable: true),
                    ClientRazaoSocial = table.Column<string>(maxLength: 128, nullable: true),
                    ClientTradeName = table.Column<string>(maxLength: 128, nullable: true),
                    TransportCode = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInvoices", x => new { x.InvoiceCode, x.Series });
                });

            // OrderDetailStatePersistences table (persisted state for list positions and checkboxes)
            migrationBuilder.CreateTable(
                name: "OrderDetailStatePersistences",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(maxLength: 32, nullable: false),
                    ItemsListSelectedKey = table.Column<string>(maxLength: 64, nullable: true),
                    ObservationsListSelectedKey = table.Column<string>(maxLength: 64, nullable: true),
                    BlocksListSelectedKey = table.Column<string>(maxLength: 64, nullable: true),
                    InvoicesListSelectedKey = table.Column<string>(maxLength: 64, nullable: true),
                    AutoLoadItemsChecked = table.Column<bool>(nullable: false, defaultValue: true),
                    AutoLoadObservationsChecked = table.Column<bool>(nullable: false, defaultValue: true),
                    AutoLoadBlocksChecked = table.Column<bool>(nullable: false, defaultValue: true),
                    AutoLoadInvoicesChecked = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailStatePersistences", x => x.OrderNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "OrderDetailStatePersistences");
            migrationBuilder.DropTable(name: "OrderInvoices");
            migrationBuilder.DropTable(name: "OrderBlocks");
            migrationBuilder.DropTable(name: "OrderObservations");
            migrationBuilder.DropTable(name: "OrderItems");
            migrationBuilder.DropTable(name: "Orders");
        }
    }
}