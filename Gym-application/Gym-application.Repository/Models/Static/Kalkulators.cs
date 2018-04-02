using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.Static
{
    public class Kalkulator_1
    {
        //https://www.budujmase.pl/diety/o-dietach/6297-obliczanie-wymaganej-ilosci-kalorii-krok-po-kroku.html 
        //private double weight, height, age, lifetype ;
        //private bool sex; //true Women
        //private Somatotyp somatotyp;
        //private Aim aim;
        public static Dictionary<double, string> life_type = new Dictionary<double, string>()
        {
            {1.0d , "leżący lub siedzący tryb życia, brak aktywności fizycznej" },
            {1.2d , "praca siedząca, aktywność fizyczna na niskim poziomie" },
            {1.4d , "praca nie fizyczna, trening 2 razy w tygodniu" },
            {1.6d , "lekka praca fizyczna, trening 3-4 razy w tygodniu" },
            {1.8d , "praca fizyczna, trening 5 razy w tygodniu" },
            {2.0d , "ciężka praca fizyczna, codzienny trening" }
        };
        public Kalkulator_1(int weight,int  height, int age,bool sex)
        {

        }
        //Harrisa-Benedicta
        //          Wzór dla mężczyzn: [A] = 66,5 + (13,7 x WAGA) + (5 x WZROST) – (6,8 x WIEK)
        //          Wzór dla kobiet:     [A] = 655 + (9,6 x WAGA) + (1,85 x WZROST) – (4,7 x WIEK)
        //Mifflin-St Jeor
        //          Wzór dla mężczyzn: [A] = (9,99 x WAGA) + (6,25 x WZROST) – (4,92 x WIEK) +5
        //          Wzór dla kobiet:     [A] = (9,99 x WAGA) + (6,25 x WZROST) – (4,92 x WIEK) - 161
        //Katch-McArdle
        //          Wzór dla mężczyzn: [A] = 370 + (21,6 x masa mięśniowa ciała w kg)
        //          Wzór dla kobiet:     [A] = 370 + (21,6 x masa mięśniowa ciała w kg)
        private double Calculate_BMR(double weight,double height,int age,bool sex,string Kind,double? mass_muscle) //true =woman
        {
            double BMR = 0;
            switch (Kind)
            {
                case "HB":
                    BMR = (sex) ? 655 + (9.6 * weight) + (1.85 * height) - (4.7 * age): 66.5 + (13.7 * weight) + (5 * height) - (6.8 * age);              
                    break;
                case "MSJ":
                    BMR = (sex) ? (9.99 * weight) + (1.85 * height) - (4.7 * age)-161 :(13.7 * weight) + (5 * height) - (6.8 * age)+5;
                    break;
                case "KM":
                    BMR = (mass_muscle!=null)? 655 + 370 + (21.6*(double)mass_muscle):1;
                    break;
            }
            return BMR;

            
        }
        private double Calculate_type_life(double BMR, double life_const)
        {
            return BMR * life_const;
        }
        //private double Calculate_somatotyp()
        //{
        //    // Building Ekto +20% ,Mezo +15%, Endo +10%
        //    // Reduc Ekto -10%, Mezo +15%, Endo -20%
        //    double calculate = Calculate_type_life();
        //    if (aim == Aim.Building)
        //    {
        //        calculate = (somatotyp == Somatotyp.Ektomorfik) ? calculate * 1.2 : (somatotyp == Somatotyp.Mezomorfik) ? calculate * 1.15 : calculate * 1.1;
        //    }
        //    else
        //    {
        //        calculate = (somatotyp == Somatotyp.Ektomorfik) ? calculate * 0.9 : (somatotyp == Somatotyp.Mezomorfik) ? calculate * 0.85 : calculate * 0.8;
        //    }
        //    return calculate;
        //}

    }
    public enum Somatotyp
    {
        Ektomorfik,Mezomorfik,Endomorfik
    }
    public enum Aim
    {
        Building, Reduction
    }
}
