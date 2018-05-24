using Gym_application.Repository.Models.DataBase;
using Gym_application.Repository.Models.ViewModels.DietViewModels;
using Gym_application.Repository.Models.ViewModels.MealViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_application.Repository.Models.IRepo
{
    public interface IMealRepo
    {
        //IQueryable<Diet> UserDietList(string userId);
        void AddMealAsync(Meal meal);
        Task<Meal> GetMealAsync(int id);
        Task<MealViewModel> MealData(int id);
        Task<int> SaveChangesAsync();


        //values
        Task<List<Nutritional_Value>> GetValuesAsync();
        Task<bool> Check__Modify_Save(MealViewModel date, string userId);
        //IQueryable<ViewDietModel> Get_Days_and_Meals_for_Diet(int dietId);
        //bool Check_Access_to_Diet(int dietId, string userId);
    }
}
