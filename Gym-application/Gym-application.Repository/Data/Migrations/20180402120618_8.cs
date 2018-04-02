using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "somatotyp",
                table: "User_Details",
                newName: "Somatotyp");

            migrationBuilder.RenameColumn(
                name: "calculator_Type",
                table: "User_Details",
                newName: "Calculator_Type");

            migrationBuilder.RenameColumn(
                name: "activity",
                table: "User_Details",
                newName: "Activity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Somatotyp",
                table: "User_Details",
                newName: "somatotyp");

            migrationBuilder.RenameColumn(
                name: "Calculator_Type",
                table: "User_Details",
                newName: "calculator_Type");

            migrationBuilder.RenameColumn(
                name: "Activity",
                table: "User_Details",
                newName: "activity");
        }
    }
}
