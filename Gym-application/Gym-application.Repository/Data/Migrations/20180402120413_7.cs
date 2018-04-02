using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Authomatic_calculate",
                table: "User_Details",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "activity",
                table: "User_Details",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "calculator_Type",
                table: "User_Details",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authomatic_calculate",
                table: "User_Details");

            migrationBuilder.DropColumn(
                name: "activity",
                table: "User_Details");

            migrationBuilder.DropColumn(
                name: "calculator_Type",
                table: "User_Details");
        }
    }
}
