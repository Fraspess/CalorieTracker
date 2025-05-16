using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class CalorieCalculator
    {
        public enum Gender
        {
            Male,
            Female
        }

        public enum Goal
        {
            LoseWeight,
            GainWeight
        }

        public Gender UserGender { get; set; }
        public double WeightKg { get; set; }
        public double HeightCm { get; set; }
        public int Age { get; set; }
        public Goal UserGoal { get; set; }

        public CalorieCalculator(Gender gender, double weightKg, double heightCm, int age, Goal goal)
        {
            UserGender = gender;
            WeightKg = weightKg;
            HeightCm = heightCm;
            Age = age;
            UserGoal = goal;
        }

        public double Calculate()
        {
            double bmr;

            if (UserGender == Gender.Male)
                bmr = 10 * WeightKg + 6.25 * HeightCm - 5 * Age + 5;
            else
                bmr = 10 * WeightKg + 6.25 * HeightCm - 5 * Age - 161;

            if (UserGoal == Goal.LoseWeight)
                return bmr - 500;
            else 
                return bmr + 500;
        }
    }
}
