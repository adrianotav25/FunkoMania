using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunkoMania.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fm_Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 5, 31, 18, 17, 18, 179, DateTimeKind.Local).AddTicks(5355)),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fm_Client_fm_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "fm_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fm_Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoucherUsed = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fm_Order_fm_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "fm_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fm_OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_OrderItems_Order",
                        column: x => x.OrderId,
                        principalTable: "fm_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fm_Client_AddressId",
                table: "fm_Client",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_fm_Order_AddressId",
                table: "fm_Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_fm_OrderItem_OrderId",
                table: "fm_OrderItem",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fm_Client");

            migrationBuilder.DropTable(
                name: "fm_OrderItem");

            migrationBuilder.DropTable(
                name: "fm_Product");

            migrationBuilder.DropTable(
                name: "fm_Order");

            migrationBuilder.DropTable(
                name: "fm_Address");
        }
    }
}
