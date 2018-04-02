using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "User_Details",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "somatotyp",
                table: "User_Details",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "User_Details");

            migrationBuilder.DropColumn(
                name: "somatotyp",
                table: "User_Details");

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }
    }
}
