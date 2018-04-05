using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gym_application.GYMMY.Data.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Details_AspNetUsers_UserId",
                table: "User_Details");

            migrationBuilder.DropIndex(
                name: "IX_User_Details_UserId",
                table: "User_Details");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User_Details");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Details_AspNetUsers_Id",
                table: "User_Details",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Details_AspNetUsers_Id",
                table: "User_Details");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "User_Details",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Details_UserId",
                table: "User_Details",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Details_AspNetUsers_UserId",
                table: "User_Details",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
