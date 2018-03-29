using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Calories_after_BMR_multiply_activity",
                table: "User_Detail",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Calories_for_calculators",
                table: "User_Detail",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Diet_Meal_DietId",
                table: "Diet_Meal",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Diet_Meal_MealId",
                table: "Diet_Meal",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diet_Meal_Diet_DietId",
                table: "Diet_Meal",
                column: "DietId",
                principalTable: "Diet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diet_Meal_Meal_MealId",
                table: "Diet_Meal",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diet_Meal_Diet_DietId",
                table: "Diet_Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Diet_Meal_Meal_MealId",
                table: "Diet_Meal");

            migrationBuilder.DropIndex(
                name: "IX_Diet_Meal_DietId",
                table: "Diet_Meal");

            migrationBuilder.DropIndex(
                name: "IX_Diet_Meal_MealId",
                table: "Diet_Meal");

            migrationBuilder.DropColumn(
                name: "Calories_after_BMR_multiply_activity",
                table: "User_Detail");

            migrationBuilder.DropColumn(
                name: "Calories_for_calculators",
                table: "User_Detail");
        }
    }
}
