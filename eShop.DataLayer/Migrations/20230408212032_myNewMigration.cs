﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class myNewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Customers");
        }
    }
}
