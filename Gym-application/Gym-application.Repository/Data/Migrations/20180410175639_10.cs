using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "User_Details");

            migrationBuilder.AddColumn<byte>(
                name: "Height",
                table: "Sizes",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Muscle_Mass",
                table: "Sizes",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "Muscle_Mass",
                table: "Sizes");

            migrationBuilder.AddColumn<byte>(
                name: "Height",
                table: "User_Details",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
