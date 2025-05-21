using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{

    public class CalorieCalculator
    {
        public enum ActivityLevel
        {
            Sedentary = 1,
            LightlyActive = 2,
            ModeratelyActive = 3,
            VeryActive = 4,
            ExtremelyActive = 5
        }

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
        public ActivityLevel UserActivityLevel { get; set; }

        public CalorieCalculator(Gender gender, double weightKg, double heightCm, int age, Goal goal, ActivityLevel activityLevel)
        {
            UserGender = gender;
            WeightKg = weightKg;
            HeightCm = heightCm;
            Age = age;
            UserGoal = goal;
            UserActivityLevel = activityLevel;
        }

        public double Calculate()
        {
            double bmr;

            if (UserGender == Gender.Male)
                bmr = 10 * WeightKg + 6.25 * HeightCm - 5 * Age + 5;
            else
                bmr = 10 * WeightKg + 6.25 * HeightCm - 5 * Age - 161;

            double activityMultiplier = UserActivityLevel switch
            {
                ActivityLevel.Sedentary => 1.2,
                ActivityLevel.LightlyActive => 1.375,
                ActivityLevel.ModeratelyActive => 1.55,
                ActivityLevel.VeryActive => 1.725,
                ActivityLevel.ExtremelyActive => 1.9,
                _ => 1.2
            };

            bmr *= activityMultiplier;

            if (UserGoal == Goal.LoseWeight)
                return bmr - 500;
            else
                return bmr + 500;
        }

    }
}
