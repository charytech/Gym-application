using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutritional_Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calorie = table.Column<short>(nullable: false),
                    Carbohydrates = table.Column<short>(nullable: false),
                    Fat = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Protein = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutritional_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Biceps = table.Column<byte>(nullable: false),
                    Chest = table.Column<byte>(nullable: false),
                    Create_Date = table.Column<DateTime>(nullable: false),
                    Fat = table.Column<byte>(nullable: false),
                    Forearm = table.Column<byte>(nullable: false),
                    Hips = table.Column<byte>(nullable: false),
                    Kind_Of_Sizes = table.Column<int>(nullable: false),
                    Thigh = table.Column<byte>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Waist = table.Column<byte>(nullable: false),
                    Weight = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sizes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Details",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Aim = table.Column<int>(nullable: false),
                    Calories_after_BMR_multiply_activity = table.Column<short>(nullable: true),
                    Calories_for_calculators = table.Column<short>(nullable: true),
                    Height = table.Column<byte>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Details_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diet_Meals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DietId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false),
                    Number_of_Meal_At_The_Week = table.Column<short>(nullable: false),
                    Which_meal_at_the_day = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diet_Meals_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diet_Meals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meal__Nutritional_Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MealId = table.Column<int>(nullable: false),
                    Nutritional_ValuesId = table.Column<int>(nullable: false),
                    Quantity_grams = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal__Nutritional_Values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal__Nutritional_Values_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meal__Nutritional_Values_Nutritional_Values_Nutritional_ValuesId",
                        column: x => x.Nutritional_ValuesId,
                        principalTable: "Nutritional_Values",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Diet_Meals_DietId",
                table: "Diet_Meals",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Diet_Meals_MealId",
                table: "Diet_Meals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserId",
                table: "Diets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal__Nutritional_Values_MealId",
                table: "Meal__Nutritional_Values",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal__Nutritional_Values_Nutritional_ValuesId",
                table: "Meal__Nutritional_Values",
                column: "Nutritional_ValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_UserId",
                table: "Sizes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Details_UserId",
                table: "User_Details",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Diet_Meals");

            migrationBuilder.DropTable(
                name: "Meal__Nutritional_Values");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "User_Details");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Nutritional_Values");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }
    }
}
