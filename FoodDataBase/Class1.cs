using System;
using System.Linq;

namespace FoodDataBase;

public class Class1
{
    public static void Main(string[] args)
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        var allFoods = db.Foods.ToList();
        foreach (var food in allFoods)
        {
            Console.WriteLine($"{food.FoodName} - {food.CaloriesPer100g} kcal");
        }
    }
}
