using Gym_application.Repository.Models.DataBase;
using Gym_application.Repository.Models.ViewModels.DietViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_application.Repository.Models.IRepo
{
    public interface IDietRepo
    {
        IQueryable<Diet> UserDietList(string userId);
        void AddDiet(Diet diet);
        Task<Diet> GetDiet(int id);
        Task<int> SaveChangesAsync();
        IQueryable<ViewDietModel> Get_Days_and_Meals_for_Diet(int dietId);
        bool Check_Access_to_Diet(int dietId,string userId);
    }
}
