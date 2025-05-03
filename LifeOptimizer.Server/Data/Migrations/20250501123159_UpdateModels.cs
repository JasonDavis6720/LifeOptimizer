using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeOptimizer.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "Dwellings",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Dwellings",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Dwellings",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Dwellings",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Dwellings",
                newName: "StreetAddress");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StorageItemId1",
                table: "Shelves",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Dwellings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "USA");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "Dwellings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_StorageItemId1",
                table: "Shelves",
                column: "StorageItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelves_StorageItems_StorageItemId1",
                table: "Shelves",
                column: "StorageItemId1",
                principalTable: "StorageItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelves_StorageItems_StorageItemId1",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Shelves_StorageItemId1",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StorageItemId1",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Dwellings");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Dwellings",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Dwellings",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Dwellings",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Dwellings",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Dwellings",
                newName: "Address_Street");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "Dwellings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "USA",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
