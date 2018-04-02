using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.DataBase
{
    public class Nutritional_Value
    {
        public Nutritional_Value()
        {
            this.Meal__Nutritional_Values = new HashSet<Meal__Nutritional_Value>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        // will be save multiply 10 examle : if u will want save 49,2 Protein u need save it like 492
        public short Calorie { get; set; }
        public short Protein { get; set; }
        public short Fat { get; set; }
        public short Carbohydrates { get; set; }
        public bool Dish { get; set; }
        public string Accepted { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Meal__Nutritional_Value> Meal__Nutritional_Values { get; private set; }

    }
}
