using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Calories",
                table: "Meals",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Carbohydrates",
                table: "Meals",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Fat",
                table: "Meals",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Protein",
                table: "Meals",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Meals");
        }
    }
}
