using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Model.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Lenovo");

            migrationBuilder.InsertData(
                table: "ModelState",
                columns: new[] { "Id", "DeviceStateId", "Name" },
                values: new object[] { 1, 2, "G503" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModelState",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "G50");
        }
    }
}
