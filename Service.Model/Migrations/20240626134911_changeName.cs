using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Model.Migrations
{
    /// <inheritdoc />
    public partial class changeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prize",
                table: "ToDoState",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Prize",
                table: "ToDo",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ToDoState",
                newName: "Prize");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ToDo",
                newName: "Prize");
        }
    }
}
