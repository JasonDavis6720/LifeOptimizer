using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeOptimizer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingrooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Dwellings_DwellingId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageElements_Room_RoomId",
                table: "StorageElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_Room_DwellingId",
                table: "Rooms",
                newName: "IX_Rooms_DwellingId");

            migrationBuilder.AlterColumn<int>(
                name: "DwellingId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Dwellings_DwellingId",
                table: "Rooms",
                column: "DwellingId",
                principalTable: "Dwellings",
                principalColumn: "DwellingId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageElements_Rooms_RoomId",
                table: "StorageElements",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Dwellings_DwellingId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageElements_Rooms_RoomId",
                table: "StorageElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_DwellingId",
                table: "Room",
                newName: "IX_Room_DwellingId");

            migrationBuilder.AlterColumn<int>(
                name: "DwellingId",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Dwellings_DwellingId",
                table: "Room",
                column: "DwellingId",
                principalTable: "Dwellings",
                principalColumn: "DwellingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageElements_Room_RoomId",
                table: "StorageElements",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId");
        }
    }
}
