using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.Repo
{
    public class Nutritional_Values
    {
        public Nutritional_Values()
        {
            this.Meal__Nutritional_Values = new HashSet<Meal__Nutritional_Values>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        // will be save multiply 10 examle : if u will want save 49,2 Protein u need save it like 492
        public Int16 Calorie { get; set; }
        public Int16 Protein { get; set; }
        public Int16 Fat { get; set; }
        public Int16 Carbohydrates { get; set; }
        public ICollection<Meal__Nutritional_Values> Meal__Nutritional_Values { get; private set; }

    }
}
