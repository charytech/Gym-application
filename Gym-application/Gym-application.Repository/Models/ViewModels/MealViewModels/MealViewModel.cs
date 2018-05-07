using Gym_application.Repository.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.ViewModels.MealViewModels
{
    public class MealViewModel
    {
        public Meal Meal { get; set; }
        public IEnumerable<ValuesViewModel> Values { get; set; }
    }
    public class ValuesViewModel
    {
        public int Id { get; set; }
        public int Values_Meal_Id { get; set; }

        public string Name { get; set; }
        // will be save multiply 10 examle : if u will want save 49,2 Protein u need save it like 492
        public short Calorie { get; set; }
        public short Protein { get; set; }
        public short Fat { get; set; }
        public short Carbohydrates { get; set; }
        public int Grams { get; set; }
    }
}
