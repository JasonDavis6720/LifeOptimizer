using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeOptimizer.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressToDwelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dwellings_Address_AddressId",
                table: "Dwellings");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Dwellings_AddressId",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Dwellings");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Dwellings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Dwellings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "USA");

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Dwellings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Dwellings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Dwellings",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Dwellings");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Dwellings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dwellings_AddressId",
                table: "Dwellings",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dwellings_Address_AddressId",
                table: "Dwellings",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
