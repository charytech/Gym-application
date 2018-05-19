using Gym_application.Repository.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gym_application.Repository.Models.IRepo
{
   public interface INutritional_ValuesRepo
    {
        //IQueryable<Diet> UserDietList(string userId);
        void AddValuesAsync(Nutritional_Value values);
        Task<List<Nutritional_Value>> GetValuesAsync();
        Task<int> SaveChangesAsync();
        //IQueryable<ViewDietModel> Get_Days_and_Meals_for_Diet(int dietId);
        //bool Check_Access_to_Diet(int dietId, string userId);
    }
}
