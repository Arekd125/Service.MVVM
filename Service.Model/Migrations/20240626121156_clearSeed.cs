using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Model.Migrations
{
    /// <inheritdoc />
    public partial class clearSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModelState",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeviceState",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Lenovo" });

            migrationBuilder.InsertData(
                table: "ModelState",
                columns: new[] { "Id", "DeviceStateId", "Name" },
                values: new object[] { 1, 2, "G503" });
        }
    }
}
