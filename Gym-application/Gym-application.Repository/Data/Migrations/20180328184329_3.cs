using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diet",
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
                    table.PrimaryKey("PK_Diet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diet_Meal",
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
                    table.PrimaryKey("PK_Diet_Meal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
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
                        name: "FK_Meal__Nutritional_Values_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
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
                name: "IX_Diet_UserId",
                table: "Diet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal__Nutritional_Values_MealId",
                table: "Meal__Nutritional_Values",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal__Nutritional_Values_Nutritional_ValuesId",
                table: "Meal__Nutritional_Values",
                column: "Nutritional_ValuesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "Diet_Meal");

            migrationBuilder.DropTable(
                name: "Meal__Nutritional_Values");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Nutritional_Values");
        }
    }
}
