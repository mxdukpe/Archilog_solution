using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace archi.api.Migrations
{
    /// <inheritdoc />
    public partial class TacosModelNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Meat",
                table: "Tacos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tacos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Sauce",
                table: "Tacos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meat",
                table: "Tacos");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tacos");

            migrationBuilder.DropColumn(
                name: "Sauce",
                table: "Tacos");
        }
    }
}
