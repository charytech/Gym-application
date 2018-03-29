using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.Repo
{
    public class Diet_Meal
    {
        public int Id { get; set; }
        public Int16 Number_of_Meal_At_The_Week { get; set; }
        public int DietId { get; set; }
        public int MealId { get; set; }
        public Int16 Which_meal_at_the_day { get; set; }

    }
}
