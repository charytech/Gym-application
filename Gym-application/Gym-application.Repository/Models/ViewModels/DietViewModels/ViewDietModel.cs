using Gym_application.Repository.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_application.Repository.Models.ViewModels.DietViewModels
{
    public class ViewDietModel
    {
        public short Which_day { get; set; }
        public IEnumerable<Meal> ListMeals { get; set; }
    }
}
