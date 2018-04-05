using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gym_application.Repository.Models.DataBase
{
    public class User_Detail
    {
        public User_Detail()
        {

        }
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public Kind_of_Aim Aim { get; set;}
        public Somatotyp Somatotyp { get; set; }
        public byte Height { get; set; }
        public bool Sex { get; set; } // Woman =True   
        public short Activity { get; set; }
        public Calculator_type Calculator_Type { get; set; }
        public bool Authomatic_calculate { get; set; }
        public short? Calories_after_BMR_multiply_activity { get; set; }
        public short? Calories_for_calculators { get; set; }
        public User User { get; set; }
        [NotMapped]
        public int Totaly_Calories => (Aim == Kind_of_Aim.Reduction) ? (int)Calories_after_BMR_multiply_activity - (int)Calories_for_calculators : (Aim == Kind_of_Aim.Mass) ? (int)Calories_after_BMR_multiply_activity + (int)Calories_for_calculators : (int)Calories_after_BMR_multiply_activity; 

        
        //#region Aim 
        //public Int16 Aim_Weight { get; set; }
        //public Byte Aim_Biceps { get; set; }
        //public Byte Aim_Pas { get; set; }
        //public Byte Aim_Klatka { get; set; }
        //public Byte Aim_Udo { get; set; }
        //public Byte Aim_Przedramie { get; set; }
        //public Byte Aim_Biodra { get; set; }
        //public Byte Aim_Tkanka_tluszczowa { get; set; }
        //#endregion
        //#region Aktual_sizes
        //public Int16 Aktual_Weight { get; set; }
        //public Byte Aktual_Biceps { get; set; }
        //public Byte Aktual_Pas { get; set; }
        //public Byte Aktual_Klatka { get; set; }
        //public Byte Aktual_Udo { get; set; }
        //public Byte Aktual_Przedramie { get; set; }
        //public Byte Aktual_Biodra { get; set; }
        //public Byte Aktual_Tkanka_tluszczowa { get; set; }
        //#endregion

    }
    public enum Kind_of_Aim
    {
        Reduction, Mass, Keep
    }
    public enum Somatotyp
    {
        Ektomorfik, Mezomorfik, Endomorfik
    }
    public enum Calculator_type
    {
        HB,MSJ,KM
    }
}
