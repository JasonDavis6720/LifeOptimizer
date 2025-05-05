using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeOptimizer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelRefactorParentRelationshipsNOElemntId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_StorageElements_StorageElementId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "StorageElementId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_StorageElements_StorageElementId",
                table: "Items",
                column: "StorageElementId",
                principalTable: "StorageElements",
                principalColumn: "StorageElementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_StorageElements_StorageElementId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "StorageElementId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_StorageElements_StorageElementId",
                table: "Items",
                column: "StorageElementId",
                principalTable: "StorageElements",
                principalColumn: "StorageElementId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
