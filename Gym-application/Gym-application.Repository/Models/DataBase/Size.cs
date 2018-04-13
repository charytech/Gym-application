using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool My_Equal (Object obj)
        {
            if (obj == null || !(obj is Size))
                return false;
            else
            {
                Size bufor = (Size)obj;
                return (this.Biceps == bufor.Biceps &&
                    this.Chest == bufor.Chest &&
                    this.Fat == bufor.Fat &&
                    this.Forearm == bufor.Forearm &&
                    this.Height == bufor.Height &&
                    this.Hips == bufor.Hips &&
                    this.Muscle_Mass == bufor.Muscle_Mass &&
                    this.Thigh == bufor.Thigh &&
                    this.Waist == bufor.Waist &&
                    this.Weight == bufor.Weight)?true:false;
            }               
        }
    }
    public enum Kind_of_Sizes
    {// before- rozmiary do ktorych bede po
        Before,Aim,Story,Actual
    }
   
}
