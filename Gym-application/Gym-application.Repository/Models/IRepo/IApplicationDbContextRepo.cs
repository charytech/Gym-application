using Gym_application.Repository.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Gym_application.Repository.Models.IRepo
{
    public interface IApplicationDbContextRepo
    {
        DbSet<Diet> Diets { get; set; }
        DbSet<Diet_Meal> Diet_Meals { get; set; }
        DbSet<Meal> Meals { get; set; }
        DbSet<Meal__Nutritional_Value> Meal__Nutritional_Values { get; set; }
        DbSet<Nutritional_Value> Nutritional_Values { get; set; }
        DbSet<Size> Sizes { get; set; }
        DbSet<User> User { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken= default(CancellationToken));

        DbSet<User_Detail> User_Details { get; set; }
        int SaveChanges();
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Update(Object entity);
        Database Database { get; }
    }
}
