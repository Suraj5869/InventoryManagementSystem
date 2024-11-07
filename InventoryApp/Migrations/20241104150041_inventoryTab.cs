using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.Migrations
{
    /// <inheritdoc />
    public partial class inventoryTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_InventoryId",
                table: "transactions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_InventoryId",
                table: "suppliers",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_InventoryId",
                table: "products",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_inventories_InventoryId",
                table: "products",
                column: "InventoryId",
                principalTable: "inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_inventories_InventoryId",
                table: "suppliers",
                column: "InventoryId",
                principalTable: "inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_inventories_InventoryId",
                table: "transactions",
                column: "InventoryId",
                principalTable: "inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_inventories_InventoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_inventories_InventoryId",
                table: "suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_inventories_InventoryId",
                table: "transactions");

            migrationBuilder.DropTable(
                name: "inventories");

            migrationBuilder.DropIndex(
                name: "IX_transactions_InventoryId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_InventoryId",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_products_InventoryId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "products");
        }
    }
}
