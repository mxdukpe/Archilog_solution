using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace archi.api.Migrations
{
    /// <inheritdoc />
    public partial class BaseModelCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Tacos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tacos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Tacos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Pizzas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Pizzas",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Tacos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tacos");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Tacos");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Pizzas");
        }
    }
}
