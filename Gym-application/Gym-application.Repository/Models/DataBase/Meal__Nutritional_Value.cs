using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.DataBase
{
    public class Meal__Nutritional_Value
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int Nutritional_ValuesId { get; set; }
        public short Quantity_grams { get; set; }
        public virtual Nutritional_Value Nutritional_Values { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
