using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaWebApp.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class FillData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Salami, ham, bacon, mushroom, green pepper.", "https://placehold.co/602x402", "Pepperoni Special" },
                    { 2, "Mushroom, onion, green pepper, sweet corn, black olives.", "https://placehold.co/602x402", "Vegetarian" },
                    { 3, "Slice tomato.", "https://placehold.co/602x402", "Margarita" },
                    { 4, "Ham, pineapple.", "https://placehold.co/602x402", "Hawaiian" },
                    { 5, "Ham, mushroom, prawns, artichoke, black olives", "https://placehold.co/602x402", "Quattro Stagioni" },
                    { 6, "Ham, mushroom", "https://placehold.co/602x402", "Capricciosa" },
                    { 7, "Prawns, mushroom.", "https://placehold.co/602x402", "Riviera" },
                    { 8, "Pesto base sauce, marinated grilled chicken, mozzarella cheese, tomato.", "https://placehold.co/602x402", "Chicken Pesto" },
                    { 9, "Tuna, anchovies, black olives.", "https://placehold.co/602x402", "Frutti di Mare" },
                    { 10, "Ham, mushroom, pepperoni, haloumi, green pepper, onion, black olives, tomato, oregano.", "https://placehold.co/602x402", "Super Crazy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
