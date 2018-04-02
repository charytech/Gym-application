using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.DataBase
{
    public class Diet
    {
        public Diet()
        {
            this.Diet_Meal = new HashSet<Diet_Meal>();
        }
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string UserId { get; set; }
        public string OwnerId { get; set; }
        public DateTime Created_Date { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Diet_Meal> Diet_Meal { get; private set; }
    }
}
