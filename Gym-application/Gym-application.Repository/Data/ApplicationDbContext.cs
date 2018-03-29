﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gym_application.Repository.Models.Repo;

namespace Gym_application.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            var cascadeFKs = builder.Model.GetEntityTypes()
        .SelectMany(t => t.GetForeignKeys())
        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            base.OnModelCreating(builder);
        }
        public DbSet<Diet> Diet { get; set; }
        public DbSet<Diet_Meal> Diet_Meal { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Meal__Nutritional_Values> Meal__Nutritional_Values { get; set; }
        public DbSet<Nutritional_Values> Nutritional_Values { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<User_Detail> User_Detail { get; set; }

    }
}