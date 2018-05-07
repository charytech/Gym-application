using Gym_application.Repository.Models.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Gym_application.Repository.Models.DataBase;
using System.Linq;
using Gym_application.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Gym_application.Repository.Models.ViewModels.DietViewModels;

namespace Gym_application.Repository.Models.Repo
{
    public class DietRepo : IDietRepo
    {
        private IApplicationDbContextRepo _db;
        public DietRepo(IApplicationDbContextRepo db)
        {
            _db = db;
        }

        public void AddDiet(Diet diet)
        {
            _db.Diets.Add(diet);
        }

        public IQueryable<ViewDietModel> Get_Days_and_Meals_for_Diet(int dietId)
        {
            //var c = _db.Diet_Meals.Where(t => t.DietId == id).Include(d => d.Meal).GroupBy(t => t.Number_of_Meal_At_The_Week).Select(g=> new {a=g.Key,z=g });
            var c = _db.Diet_Meals.Where(t => t.DietId == dietId)
                .Include(d => d.Meal)
                .GroupBy(a => a.Number_of_Meal_At_The_Week)
                .Select(x=> new ViewDietModel {Which_day = x.Key,ListMeals=x.OrderBy(m=>m.Id).Select(z=>z.Meal)});
            return c;


            //var c = _db.Diet_Meals.Where(t => t.DietId == dietId)
            //    .Include(d => d.Meal);
            //var zax = new DD
            //{
            //    ListMea = c.GroupBy(z => z.Meal).Select(zx => zx.Key),
            //    views = c.GroupBy(a => a.Number_of_Meal_At_The_Week)
            //    .Select(x => new ViewDietModel { Which_day = x.Key, ListMeals = x.OrderBy(m => m.Id).Select(z => z.Meal) })
            //};



        }
        public Task<Diet> GetDiet(int id)=>_db.Diets.SingleOrDefaultAsync(m => m.Id == id);

        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        public IQueryable<Diet> UserDietList(string userId) => _db.Diets.Where(t => t.UserId == userId).AsNoTracking();


        public async Task<List<Diet>> UserDietListAsync(string userId)
        {
            return await _db.Diets.Where(t => t.UserId == userId).ToListAsync();
            
        }
        

        public bool Check_Access_to_Diet(int dietId, string userId)
        {
            var a = GetDiet(dietId).Result;
            return (a.OwnerId == userId || a.UserId == userId);
        }
    }
    
}
