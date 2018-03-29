using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diet_AspNetUsers_UserId",
                table: "Diet");

            migrationBuilder.DropForeignKey(
                name: "FK_Diet_Meal_Diet_DietId",
                table: "Diet_Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Diet_Meal_Meal_MealId",
                table: "Diet_Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal__Nutritional_Values_Meal_MealId",
                table: "Meal__Nutritional_Values");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Detail_AspNetUsers_UserId",
                table: "User_Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Detail",
                table: "User_Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diet_Meal",
                table: "Diet_Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diet",
                table: "Diet");

            migrationBuilder.RenameTable(
                name: "User_Detail",
                newName: "User_Details");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Meals");

            migrationBuilder.RenameTable(
                name: "Diet_Meal",
                newName: "Diet_Meals");

            migrationBuilder.RenameTable(
                name: "Diet",
                newName: "Diets");

            migrationBuilder.RenameIndex(
                name: "IX_User_Detail_UserId",
                table: "User_Details",
                newName: "IX_User_Details_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Diet_Meal_MealId",
                table: "Diet_Meals",
                newName: "IX_Diet_Meals_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Diet_Meal_DietId",
                table: "Diet_Meals",
                newName: "IX_Diet_Meals_DietId");

            migrationBuilder.RenameIndex(
                name: "IX_Diet_UserId",
                table: "Diets",
                newName: "IX_Diets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Details",
                table: "User_Details",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diet_Meals",
                table: "Diet_Meals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diets",
                table: "Diets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diet_Meals_Diets_DietId",
                table: "Diet_Meals",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diet_Meals_Meals_MealId",
                table: "Diet_Meals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_AspNetUsers_UserId",
                table: "Diets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal__Nutritional_Values_Meals_MealId",
                table: "Meal__Nutritional_Values",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Details_AspNetUsers_UserId",
                table: "User_Details",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diet_Meals_Diets_DietId",
                table: "Diet_Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Diet_Meals_Meals_MealId",
                table: "Diet_Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Diets_AspNetUsers_UserId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal__Nutritional_Values_Meals_MealId",
                table: "Meal__Nutritional_Values");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Details_AspNetUsers_UserId",
                table: "User_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Details",
                table: "User_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diets",
                table: "Diets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diet_Meals",
                table: "Diet_Meals");

            migrationBuilder.RenameTable(
                name: "User_Details",
                newName: "User_Detail");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "Meal");

            migrationBuilder.RenameTable(
                name: "Diets",
                newName: "Diet");

            migrationBuilder.RenameTable(
                name: "Diet_Meals",
                newName: "Diet_Meal");

            migrationBuilder.RenameIndex(
                name: "IX_User_Details_UserId",
                table: "User_Detail",
                newName: "IX_User_Detail_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Diets_UserId",
                table: "Diet",
                newName: "IX_Diet_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Diet_Meals_MealId",
                table: "Diet_Meal",
                newName: "IX_Diet_Meal_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Diet_Meals_DietId",
                table: "Diet_Meal",
                newName: "IX_Diet_Meal_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Detail",
                table: "User_Detail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diet",
                table: "Diet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diet_Meal",
                table: "Diet_Meal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diet_AspNetUsers_UserId",
                table: "Diet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Meal__Nutritional_Values_Meal_MealId",
                table: "Meal__Nutritional_Values",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Detail_AspNetUsers_UserId",
                table: "User_Detail",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
