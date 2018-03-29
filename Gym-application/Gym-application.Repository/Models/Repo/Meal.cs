using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.Repo
{
    public class Meal
    {
        public Meal()
        {
            this.Meal__Nutritional_Values = new HashSet<Meal__Nutritional_Values>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Meal__Nutritional_Values> Meal__Nutritional_Values { get; private set; }
    }
}
