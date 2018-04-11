using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.DataBase
{
    public class Size
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public Kind_of_Sizes Kind_Of_Sizes { get; set; }
        public Int16 Weight { get; set; }
        public Byte Biceps { get; set; }
        public Byte Waist { get; set; } //talia
        public Byte Height { get; set; }
        public Byte Chest { get; set; }
        public Byte Thigh { get; set; }   // udo
        public Byte Forearm { get; set; }
        public Byte Hips { get; set; }   //biodra
        public Byte Fat { get; set; }
        public Byte Muscle_Mass { get; set; }
        public DateTime Create_Date { get; set; }
        public User User { get; set; }
    }
    public enum Kind_of_Sizes
    {// before- rozmiary do ktorych bede po
        Before,Aim,Story,Now
    }
   
}
