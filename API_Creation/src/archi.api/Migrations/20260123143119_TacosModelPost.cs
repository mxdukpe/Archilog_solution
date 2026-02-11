using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace archi.api.Migrations
{
    /// <inheritdoc />
    public partial class TacosModelPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meat",
                table: "Tacos");

            migrationBuilder.RenameColumn(
                name: "Sauce",
                table: "Tacos",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tacos",
                newName: "Sauce");

            migrationBuilder.AddColumn<string>(
                name: "Meat",
                table: "Tacos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
