﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.DataBase
{
    public class Meal
    {
        public Meal()
        {
            this.Meal__Nutritional_Values = new HashSet<Meal__Nutritional_Value>();
            this.Diet_Meal = new HashSet<Diet_Meal>();

        }
        public int Id { get; set; }
        public string Name { get; set; }

        #region Calculate from Nurtitional Values
        public short Calories { get; set; } = 0;
        public short Protein { get; set; } = 0;
        public short Fat { get; set; } = 0;
        public short Carbohydrates { get; set; } = 0;
        #endregion

        public ICollection<Meal__Nutritional_Value> Meal__Nutritional_Values { get; private set; }
        public ICollection<Diet_Meal> Diet_Meal { get; private set; }

    }
}
