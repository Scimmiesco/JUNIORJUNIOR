using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JJ.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class primeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://placehold.co/300x200/3b82f6/white?text=Notebook+SQL", "Notebook Gamer X", 7499.90m },
                    { 2, "https://placehold.co/300x200/ef4444/white?text=Mouse+SQL", "Mouse Pro Gamer", 129.50m },
                    { 3, "https://placehold.co/300x200/22c55e/white?text=Teclado+SQL", "Teclado Mecânico Avançado", 499.00m },
                    { 4, "https://placehold.co/300x200/6366f1/white?text=Monitor+SQL", "Monitor UltraWide 34\"", 2899.99m },
                    { 5, "https://placehold.co/300x200/ec4899/white?text=Headset+SQL", "Headset Gamer Imersivo", 350.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
