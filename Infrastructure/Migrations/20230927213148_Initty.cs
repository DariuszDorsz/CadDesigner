using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadDesigner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designers_Addresses_AddressId",
                table: "Designers");

            migrationBuilder.DropIndex(
                name: "IX_Designers_AddressId",
                table: "Designers");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Designers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Designers_AddressId",
                table: "Designers",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Designers_Addresses_AddressId",
                table: "Designers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designers_Addresses_AddressId",
                table: "Designers");

            migrationBuilder.DropIndex(
                name: "IX_Designers_AddressId",
                table: "Designers");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Designers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Designers_AddressId",
                table: "Designers",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Designers_Addresses_AddressId",
                table: "Designers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
