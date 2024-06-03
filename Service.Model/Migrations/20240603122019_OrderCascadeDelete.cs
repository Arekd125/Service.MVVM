using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Model.Migrations
{
    /// <inheritdoc />
    public partial class OrderCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contacts_ContactId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contacts_ContactId",
                table: "Orders",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contacts_ContactId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contacts_ContactId",
                table: "Orders",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
