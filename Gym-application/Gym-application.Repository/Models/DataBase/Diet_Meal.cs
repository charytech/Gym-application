using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.DataBase
{
    public class Diet_Meal
    {
        public int Id { get; set; }
        public short Number_of_Meal_At_The_Week { get; set; }
        public int DietId { get; set; }
        public int MealId { get; set; }
        public short Which_meal_at_the_day { get; set; }
        public Diet Diet { get; set; }
        public Meal Meal { get; set; }

    }
}
