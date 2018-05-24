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
                        Value_Id = t.Nutritional_Values.Id,
                        Nutritional_Values_Meal_Id = t.Id,
                        Carbohydrates = t.Nutritional_Values.Carbohydrates,
                        Calorie = t.Nutritional_Values.Calorie,
                        Fat = t.Nutritional_Values.Fat,
                        Grams = t.Quantity_grams,
                        Name = t.Nutritional_Values.Name,
                        Protein = t.Nutritional_Values.Protein
                    }).ToListAsync()
                };
                
            });


        }
        // values
        public async Task<bool> Check__Modify_Save(MealViewModel date, string userId)
        {
            List<ValuesViewModel> withid_should_be_exist, withoutid_should_create;
            withid_should_be_exist = date.Values.Where(t => t.Nutritional_Values_Meal_Id != 0).ToList();
            withoutid_should_create = date.Values.Where(t => t.Nutritional_Values_Meal_Id == 0).ToList();
            var x = await MealData(date.Meal.Id);

            List<ValuesViewModel> for_delete = new List<ValuesViewModel>();
            List<ValuesViewModel> for_modify = new List<ValuesViewModel>();

            foreach (var exist_in_db in x.Values)
            {
                var meal_values= withid_should_be_exist.Where(t => t.Nutritional_Values_Meal_Id == exist_in_db.Nutritional_Values_Meal_Id).FirstOrDefault();
                if (meal_values == null)
                {
                    for_delete.Add(exist_in_db);
                }
                else if(meal_values.Grams != exist_in_db.Grams)
                {
                    for_modify.Add(exist_in_db);
                }
            }
            //musze to kurde naprawic

            //foreach(var c in for_delete)
            //{
            //    _db.Meal__Nutritional_Values.Remove(new Meal__Nutritional_Value() {Id =c.Nutritional_Values_Meal_Id,MealId=date.Meal.Id, Nutritional_ValuesId=c.Value_Id, Quantity_grams= (short)c.Grams });
            //}
            return false;
        }

        public Task<List<Nutritional_Value>> GetValuesAsync()
        {
            //Thread.Sleep(2000);
            return _db.Nutritional_Values.ToListAsync();
        }






        //all together
        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
