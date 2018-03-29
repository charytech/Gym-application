using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.Repo
{
    public class Meal__Nutritional_Values
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int Nutritional_ValuesId { get; set; }
        public Int16 Quantity_grams { get; set; }
        public virtual Nutritional_Values Nutritional_Values { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
