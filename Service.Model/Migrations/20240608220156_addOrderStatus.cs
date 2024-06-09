using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Model.Migrations
{
    /// <inheritdoc />
    public partial class addOrderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contacts_ContactId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contacts_ContactId",
                table: "Orders",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contacts_ContactId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contacts_ContactId",
                table: "Orders",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }
    }
}
