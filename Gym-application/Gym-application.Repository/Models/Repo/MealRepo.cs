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
using Gym_application.Repository.Models.ViewModels.DietViewModels;

namespace Gym_application.Repository.Models.Repo
{
    public class MealRepo : IMealRepo
    {
        private IApplicationDbContextRepo _db;
        public MealRepo(IApplicationDbContextRepo db)
        {
            _db = db;
        }

        public async Task AddMealAsync(Meal meal,int dietid, ViewDietMealModel model)
        {
           
            await _db.Meals.AddAsync(meal);
            var diet_meal = new Diet_Meal()
            {
                DietId = dietid,
                MealId = meal.Id,
                Number_of_Meal_At_The_Week = model.Number_of_Meal_At_The_Week,
                Which_meal_at_day = model.Which_meal_at_day
            };
            await _db.Diet_Meals.AddAsync(diet_meal);
        }

        public async Task<Meal> GetMealAsync(int id)
        {
            return await _db.Meals.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<MealViewModel> MealData(int id)
        {
            //Thread.Sleep(5000);
            return await Task.Run(async () => {
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
            // dodać sprawdzanie userId-- chyba dodoane

            

            //divide model beetween two list
            List<ValuesViewModel> withid_should_be_exist, withoutid_should_create;
            withid_should_be_exist = date.Values.Where(t => t.Nutritional_Values_Meal_Id != 0).ToList();// should exist because have Id
            withoutid_should_create = date.Values.Where(t => t.Nutritional_Values_Meal_Id == 0).ToList();
            //var 
            var db_querry = await _db.Meal__Nutritional_Values.Where(t => t.MealId == date.Meal.Id).ToListAsync();
            List<Meal__Nutritional_Value> for_delete = new List<Meal__Nutritional_Value>();
            List<Meal__Nutritional_Value> for_modify = new List<Meal__Nutritional_Value>();
            
            foreach (var exist_in_db in db_querry)
            {
                var meal_values = withid_should_be_exist.Where(t => t.Nutritional_Values_Meal_Id == exist_in_db.Id).FirstOrDefault();
                if (meal_values == null)
                {
                    for_delete.Add(exist_in_db);
                }
                else if (meal_values.Grams != exist_in_db.Quantity_grams)
                {
                    exist_in_db.Quantity_grams = (short)meal_values.Grams;
                    for_modify.Add(exist_in_db);
                }
            }

            foreach (var delete_item in for_delete)
            {
                _db.Meal__Nutritional_Values.Remove(delete_item);
            }
            foreach (var create_item in withoutid_should_create)
            {
                await _db.Meal__Nutritional_Values.AddAsync(new Meal__Nutritional_Value() { Id = create_item.Nutritional_Values_Meal_Id, MealId = date.Meal.Id, Nutritional_ValuesId = create_item.Value_Id, Quantity_grams = (short)create_item.Grams });
            }
            foreach (var modify_item in for_modify)
            {
                _db.Update(modify_item);
            }
            //update meal_model
            //Dictionary<string,decimal> dict = Calculate_makro(date);
            //await Upadate_Meal(id:date.Meal.Id, calc:(int)dict["Calc"], carbo:(int)dict["Carbo"], prot:(int)dict["Prot"], fat:(int)dict["Fat"]);

            return true;
            
        }
        public Dictionary<string,short> Calculate_makro(MealViewModel date)
        {
            decimal prot=0, calc=0, carbo=0, fat=0;
            foreach(var value in date.Values)
            {                
                prot += value.Protein * value.Grams / 100;
                calc += value.Calorie * value.Grams / 100;
                carbo += value.Carbohydrates * value.Grams / 100;
                fat += value.Fat * value.Grams / 100;
            }
            return new Dictionary<string, short>() {
                ["Prot"]= (short)(Math.Round(prot)),
                ["Calc"] = (short)(Math.Round(calc)),
                ["Carbo"] = (short)(Math.Round(carbo)),
                ["Fat"] = (short)(Math.Round(fat)) };
        }
      

        public async Task Upadate_Meal(int id, Dictionary<string,short> dict_values)
        {
            var meal = await this.GetMealAsync(id);
            if (meal.Protein != dict_values["Prot"] || meal.Calories != dict_values["Calc"] || meal.Carbohydrates != dict_values["Carbo"] || meal.Fat != dict_values["Fat"])
            {
                meal.Calories = dict_values["Calc"];
                meal.Protein = dict_values["Prot"];
                meal.Carbohydrates = dict_values["Carbo"];
                meal.Fat = dict_values["Fat"];
                _db.Update(meal);
            }
        }



        //public Task<List<Nutritional_Value>> GetValuesAsync()
        //{
        //    //Thread.Sleep(2000);
        //    return _db.Nutritional_Values.ToListAsync();
        //}
        //all together
        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        public async Task<bool> CheckAccessToDiet(string userId,int mealid)
        {
            var c = await _db.Diet_Meals.Where(t => t.MealId == mealid).Include(a => a.Diet).Where(t => t.Diet.OwnerId == userId || t.Diet.UserId == userId).FirstOrDefaultAsync();
            return (c!=null);             
        }
    }
}
