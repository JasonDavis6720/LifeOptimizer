using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeOptimizer.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class DrawerAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrawerId",
                table: "InventoryItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageItemId",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Drawers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawerNumber = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_DrawerId",
                table: "InventoryItems",
                column: "DrawerId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Drawers_DrawerId",
                table: "InventoryItems",
                column: "DrawerId",
                principalTable: "Drawers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Drawers_DrawerId",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Drawers");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_DrawerId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "DrawerId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "StorageItemId",
                table: "InventoryItems");
        }
    }
}
