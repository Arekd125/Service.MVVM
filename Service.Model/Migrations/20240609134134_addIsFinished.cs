using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Model.Migrations
{
    /// <inheritdoc />
    public partial class addIsFinished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contacts_ContactId",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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
                name: "IsFinished",
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
