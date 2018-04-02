﻿// <auto-generated />
using Gym_application.Repository.Data;
using Gym_application.Repository.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Gym_application.GYMMY.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Nazwa");

                    b.Property<string>("OwnerId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Diet_Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DietId");

                    b.Property<int>("MealId");

                    b.Property<short>("Number_of_Meal_At_The_Week");

                    b.HasKey("Id");

                    b.HasIndex("DietId");

                    b.HasIndex("MealId");

                    b.ToTable("Diet_Meals");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Calories");

                    b.Property<short>("Carbohydrates");

                    b.Property<short>("Fat");

                    b.Property<string>("Name");

                    b.Property<short>("Protein");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Meal__Nutritional_Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MealId");

                    b.Property<int>("Nutritional_ValuesId");

                    b.Property<short>("Quantity_grams");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("Nutritional_ValuesId");

                    b.ToTable("Meal__Nutritional_Values");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Nutritional_Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Accepted");

                    b.Property<short>("Calorie");

                    b.Property<short>("Carbohydrates");

                    b.Property<bool>("Dish");

                    b.Property<short>("Fat");

                    b.Property<string>("Name");

                    b.Property<short>("Protein");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Nutritional_Values");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Biceps");

                    b.Property<byte>("Chest");

                    b.Property<DateTime>("Create_Date");

                    b.Property<byte>("Fat");

                    b.Property<byte>("Forearm");

                    b.Property<byte>("Hips");

                    b.Property<int>("Kind_Of_Sizes");

                    b.Property<byte>("Thigh");

                    b.Property<string>("UserId");

                    b.Property<byte>("Waist");

                    b.Property<short>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("SurName");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.User_Detail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Activity");

                    b.Property<int>("Aim");

                    b.Property<bool>("Authomatic_calculate");

                    b.Property<int>("Calculator_Type");

                    b.Property<short?>("Calories_after_BMR_multiply_activity");

                    b.Property<short?>("Calories_for_calculators");

                    b.Property<byte>("Height");

                    b.Property<bool>("Sex");

                    b.Property<int>("Somatotyp");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("User_Details");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Diet", b =>
                {
                    b.HasOne("Gym_application.Repository.Models.DataBase.User", "User")
                        .WithMany("Diet")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Diet_Meal", b =>
                {
                    b.HasOne("Gym_application.Repository.Models.DataBase.Diet", "Diet")
                        .WithMany("Diet_Meal")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Gym_application.Repository.Models.DataBase.Meal", "Meal")
                        .WithMany("Diet_Meal")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Meal__Nutritional_Value", b =>
                {
                    b.HasOne("Gym_application.Repository.Models.DataBase.Meal", "Meal")
                        .WithMany("Meal__Nutritional_Values")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Gym_application.Repository.Models.DataBase.Nutritional_Value", "Nutritional_Values")
                        .WithMany("Meal__Nutritional_Values")
                        .HasForeignKey("Nutritional_ValuesId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Nutritional_Value", b =>
                {
                    b.HasOne("Gym_application.Repository.Models.DataBase.User", "User")
                        .WithMany("Nutritional_Value")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.Size", b =>
                {
                    b.HasOne("Gym_application.Repository.Models.DataBase.User", "User")
                        .WithMany("Size")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Gym_application.Repository.Models.DataBase.User_Detail", b =>
                {
                    b.HasOne("Gym_application.Repository.Models.DataBase.User")
                        .WithMany("User_Detail")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Gym_application.Repository.Models.DataBase.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Gym_application.Repository.Models.DataBase.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gym_application.Repository.Models.DataBase.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Gym_application.Repository.Models.DataBase.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
