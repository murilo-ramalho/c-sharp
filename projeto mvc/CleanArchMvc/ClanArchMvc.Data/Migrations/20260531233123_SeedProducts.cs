using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Description", "Price", "Stock", "Image", "CategoryId" },
                values: new object[,]
                {
                    { 1, "Caderno espiral", "Caderno espiral 100 fôlhas", 7.45m, 50, "caderno1.jpg", 1 },
                    { 2, "Estojo escolar", "Estojo escolar cinza", 5.65m, 70, "estojo1.jpg", 1 },
                    { 3, "Borracha escolar", "Borracha branca pequena", 3.25m, 80, "borracha1.jpg", 1 },
                    { 4, "Calculadora escolar", "Calculadora simples", 15.39m, 20, "calculadora1.jpg", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 });
        }
    }
}
