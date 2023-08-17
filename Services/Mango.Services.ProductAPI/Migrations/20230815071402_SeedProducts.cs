using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Pleasent product 1...", "https://madotnetmastery.blob.core.windows.net/mango/11.jpg", "Samosa", 15.0 },
                    { 2, "Appetizer", "Pleasent product 2...", "https://madotnetmastery.blob.core.windows.net/mango/12.jpg", "Paneer Tikka", 13.99 },
                    { 3, "Dessert", "Pleasent product 3...", "https://madotnetmastery.blob.core.windows.net/mango/13.jpg", "Sweet Pie", 10.99 },
                    { 4, "Entree", "Pleasent product 4...", "https://madotnetmastery.blob.core.windows.net/mango/14.jpg", "Pav Bhaji", 15.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
