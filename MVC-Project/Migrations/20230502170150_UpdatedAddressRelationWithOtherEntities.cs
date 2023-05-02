using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAddressRelationWithOtherEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Addresses_AddressId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_AddressId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Carts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AddressId",
                table: "Carts",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Addresses_AddressId",
                table: "Carts",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
