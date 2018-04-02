using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Accepted",
                table: "Nutritional_Values",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Dish",
                table: "Nutritional_Values",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Nutritional_Values",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nutritional_Values_UserId",
                table: "Nutritional_Values",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutritional_Values_AspNetUsers_UserId",
                table: "Nutritional_Values",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutritional_Values_AspNetUsers_UserId",
                table: "Nutritional_Values");

            migrationBuilder.DropIndex(
                name: "IX_Nutritional_Values_UserId",
                table: "Nutritional_Values");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Nutritional_Values");

            migrationBuilder.DropColumn(
                name: "Dish",
                table: "Nutritional_Values");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Nutritional_Values");
        }
    }
}
