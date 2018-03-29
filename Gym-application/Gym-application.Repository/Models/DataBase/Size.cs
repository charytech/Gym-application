using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.DataBase
{
    public class Size
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public Kind_of_Sizes Kind_Of_Sizes { get; set; }
        public Int16 Weight { get; set; }
        public Byte Biceps { get; set; }
        public Byte Pas { get; set; }
        public Byte Klatka { get; set; }
        public Byte Udo { get; set; }
        public Byte Przedramie { get; set; }
        public Byte Biodra { get; set; }
        public Byte Tkanka_tluszczowa { get; set; }
        public User User { get; set; }
    }
    
}
