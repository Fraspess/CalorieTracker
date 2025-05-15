using System;
using System.Linq;

class Program
{
    static void Main()
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
