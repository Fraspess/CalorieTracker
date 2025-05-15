using FoodDataBase;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Food> Foods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=FoodDatabase;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food>().HasData(
            new Food { FoodId = 1, FoodName = "Apple", CaloriesPer100g = 52},
            new Food { FoodId = 2, FoodName = "Banana", CaloriesPer100g = 89},
            new Food { FoodId = 3, FoodName = "Tomato", CaloriesPer100g = 18}
        );
    }
}
