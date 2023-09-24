using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaWebApp.ToppingAPI.Migrations
{
    /// <inheritdoc />
    public partial class FillData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.ToppingId);
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "ToppingId", "Name" },
                values: new object[,]
                {
                    { 1, "Tomatoes" },
                    { 2, "Broccoli" },
                    { 3, "Red Pepper" },
                    { 4, "Pepperoni" },
                    { 5, "Bacon" },
                    { 6, "Basil" },
                    { 7, "Mushroom" },
                    { 8, "Onion" },
                    { 9, "Extra Cheese" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topping");
        }
    }
}
