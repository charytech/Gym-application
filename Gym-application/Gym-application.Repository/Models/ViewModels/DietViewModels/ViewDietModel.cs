﻿using Gym_application.Repository.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_application.Repository.Models.ViewModels.DietViewModels
{
    //public class DD
    //{
    //    public IEnumerable<Meal> ListMea { get; set; }
    //    public IEnumerable<ViewDietModel> views { get; set; }

    //}
    public class ViewDietModel
    {
        public short Which_day { get; set; }
        public IEnumerable<Meal> ListMeals { get; set; }
    }
    public class ViewDietMealModel // this is for create meal in diet
    {
        public string Name { get; set; }
        public short Number_of_Meal_At_The_Week { get; set; }
        public short Which_meal_at_day { get; set; }
    }
}
