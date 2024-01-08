using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KirilsShop.Migrations
{
    /// <inheritdoc />
    public partial class dasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "OrdersItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersItems_OrderItemId",
                table: "OrdersItems",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_OrdersItems_OrderItemId",
                table: "OrdersItems",
                column: "OrderItemId",
                principalTable: "OrdersItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_OrdersItems_OrderItemId",
                table: "OrdersItems");

            migrationBuilder.DropIndex(
                name: "IX_OrdersItems_OrderItemId",
                table: "OrdersItems");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "OrdersItems");
        }
    }
}
