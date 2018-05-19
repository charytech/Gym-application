using Gym_application.Repository.Models.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Gym_application.Repository.Models.DataBase;
using System.Linq;
using Gym_application.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Gym_application.Repository.Models.ViewModels.MealViewModels;
using System.Diagnostics;
using System.Threading;

namespace Gym_application.Repository.Models.Repo
{
    public class MealRepo : IMealRepo
    {
        private IApplicationDbContextRepo _db;
        public MealRepo(IApplicationDbContextRepo db)
        {
            _db = db;
        }

        public void AddMealAsync(Meal meal)
        {
            _db.Meals.AddAsync(meal);
        }
        
        public async Task<Meal> GetMealAsync(int id)
        {           
            return await _db.Meals.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<MealViewModel> MealData(int id)
        {
            //Thread.Sleep(5000);
            return await Task.Run(async() => {
                return new MealViewModel()
                {
                    Meal = await _db.Meals.Where(t => t.Id == id).FirstOrDefaultAsync(),
                    Values = await _db.Meal__Nutritional_Values.Where(t => t.MealId == id).Include(t => t.Nutritional_Values).Select(t => new ValuesViewModel()
                    {
                        Id = t.Nutritional_ValuesId,
                        Values_Meal_Id = t.Id,
                        Carbohydrates = t.Nutritional_Values.Carbohydrates,
                        Calorie = t.Nutritional_Values.Fat,
                        Fat = t.Nutritional_Values.Fat,
                        Grams = t.Quantity_grams,
                        Name = t.Nutritional_Values.Name,
                        Protein = t.Nutritional_Values.Protein
                    }).ToListAsync()
                };
                
            });


        }

        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
