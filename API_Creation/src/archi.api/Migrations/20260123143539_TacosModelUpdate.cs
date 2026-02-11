using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace archi.api.Migrations
{
    /// <inheritdoc />
    public partial class TacosModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tacos",
                newName: "Sauce");

            migrationBuilder.AddColumn<bool>(
                name: "IsVegetarian",
                table: "Tacos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Meat",
                table: "Tacos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVegetarian",
                table: "Tacos");

            migrationBuilder.DropColumn(
                name: "Meat",
                table: "Tacos");

            migrationBuilder.RenameColumn(
                name: "Sauce",
                table: "Tacos",
                newName: "Description");
        }
    }
}
