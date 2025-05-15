using System;
using System.Linq;

namespace FoodDataBase.Entities;

public class FoodEntry
{
    public int Id { get; set; }
    public int FoodId { get; set; }
    public Food Food { get; set; }

    public double Grams { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
