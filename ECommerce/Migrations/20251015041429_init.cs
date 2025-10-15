using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "Production");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address_ZIPCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddress_Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddress_Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShippingAddress_ZIPCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Suppliers_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Production",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Security",
                        principalTable: "Suppliers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "Sales",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Sales",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Production",
                table: "Category",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "", false, "Electronics" },
                    { 2, "", false, "Books" },
                    { 3, "", false, "Clothing" },
                    { 4, "", false, "Home & Kitchen" },
                    { 5, "", false, "Food" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "User",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", false, "Admin", "Asd@1234", null },
                    { 2, "ali@gmail.com", false, "ali", "Asd@1234", null },
                    { 3, "ahmed@gmail.com", false, "ahmed", "Asd@1234", null }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Suppliers",
                columns: new[] { "UserId", "IsDeleted", "ShopLocation", "ShopLogo", "ShopName" },
                values: new object[] { 3, false, "Sahary, Aswan", "https://example.com/logo.png", "Tech Supplies Co." });

            migrationBuilder.InsertData(
                schema: "Production",
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ExpireDate", "IsDeleted", "Name", "Price", "PublishDate", "Quantity", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, "A high-performance laptop", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Laptop", 999.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 2, 1, "A latest model smartphone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Smartphone", 699.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 3, 1, "A best-selling Tablet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Tablet", 1999.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 4, 3, "A comfortable cotton t-shirt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "T-Shirt", 14.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 5, 4, "A powerful kitchen blender", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Blender", 49.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                schema: "Sales",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                schema: "Sales",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                schema: "Sales",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                schema: "Sales",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "Production",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                schema: "Production",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "Security",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Security");
        }
    }
}
