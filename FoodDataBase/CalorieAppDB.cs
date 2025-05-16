using FoodDataBase.Entities;
using Microsoft.EntityFrameworkCore;

public class CalorieAppDB : DbContext
{
    public DbSet<Food> Foods { get; set; }
    
    public DbSet<FoodEntry> FoodEntries { get; set; }

    public DbSet<User> Users { get; set; }

    public CalorieAppDB()
    {
        //this.Database.EnsureDeleted();
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        // міняйте на своє тут
        optionsBuilder.UseSqlServer(@"
                                         Data Source = FRASP\SQLEXPRESS;
                                         Initial Catalog = CalorieAppDB;
                                         Integrated Security = True;
                                         Connect Timeout = 2;
                                         Encrypt = False;
                                         Trust Server Certificate = True;
                                         Application Intent = ReadWrite;
                                         Multi Subnet Failover = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<FoodEntry>()
            .HasOne(fe => fe.Food)
            .WithMany()
            .HasForeignKey(fe => fe.FoodId)
            ;

        modelBuilder.Entity<FoodEntry>()
            .HasOne(fe => fe.User)
            .WithMany(u => u.FoodEntries)
            .HasForeignKey(fe => fe.UserId)
            ;




        // ініціалізуєм трохи значень (винесіть це в отдельний клас пж і зробіть набагатоооо побільше дефолтних значень)

        modelBuilder.Entity<Food>().HasData(
            new Food { Id = 1, Name = "Apple", CaloriesPer100g = 52 },
            new Food { Id = 2, Name = "Banana", CaloriesPer100g = 96 },
            new Food { Id = 3, Name = "Orange", CaloriesPer100g = 47 },
            new Food { Id = 4, Name = "Strawberry", CaloriesPer100g = 32 },
            new Food { Id = 5, Name = "Grapes", CaloriesPer100g = 69 },
            new Food { Id = 6, Name = "Watermelon", CaloriesPer100g = 30 },
            new Food { Id = 7, Name = "Pineapple", CaloriesPer100g = 50 },
            new Food { Id = 8, Name = "Mango", CaloriesPer100g = 60 },
            new Food { Id = 9, Name = "Blueberry", CaloriesPer100g = 57 },
            new Food { Id = 10, Name = "Kiwi", CaloriesPer100g = 61 },
            new Food { Id = 11, Name = "Tomato", CaloriesPer100g = 18 },
            new Food { Id = 12, Name = "Cucumber", CaloriesPer100g = 16 },
            new Food { Id = 13, Name = "Carrot", CaloriesPer100g = 41 },
            new Food { Id = 14, Name = "Potato", CaloriesPer100g = 77 },
            new Food { Id = 15, Name = "Sweet Potato", CaloriesPer100g = 86 },
            new Food { Id = 16, Name = "Broccoli", CaloriesPer100g = 34 },
            new Food { Id = 17, Name = "Cauliflower", CaloriesPer100g = 25 },
            new Food { Id = 18, Name = "Spinach", CaloriesPer100g = 23 },
            new Food { Id = 19, Name = "Onion", CaloriesPer100g = 40 },
            new Food { Id = 20, Name = "Garlic", CaloriesPer100g = 149 },
            new Food { Id = 21, Name = "Lettuce", CaloriesPer100g = 15 },
            new Food { Id = 22, Name = "Peas", CaloriesPer100g = 81 },
            new Food { Id = 23, Name = "Corn", CaloriesPer100g = 86 },
            new Food { Id = 24, Name = "Rice (cooked)", CaloriesPer100g = 130 },
            new Food { Id = 25, Name = "Pasta (cooked)", CaloriesPer100g = 131 },
            new Food { Id = 26, Name = "Bread (white)", CaloriesPer100g = 265 },
            new Food { Id = 27, Name = "Bread (whole wheat)", CaloriesPer100g = 247 },
            new Food { Id = 28, Name = "Cheese", CaloriesPer100g = 402 },
            new Food { Id = 29, Name = "Milk (whole)", CaloriesPer100g = 61 },
            new Food { Id = 30, Name = "Yogurt (plain)", CaloriesPer100g = 59 },
            new Food { Id = 31, Name = "Butter", CaloriesPer100g = 717 },
            new Food { Id = 32, Name = "Egg (boiled)", CaloriesPer100g = 155 },
                new Food { Id = 33, Name = "Chicken Breast (grilled)", CaloriesPer100g = 165 },
            new Food { Id = 34, Name = "Beef (cooked)", CaloriesPer100g = 250 },
            new Food { Id = 35, Name = "Pork (cooked)", CaloriesPer100g = 242 },
            new Food { Id = 36, Name = "Salmon", CaloriesPer100g = 208 },
            new Food { Id = 37, Name = "Tuna (canned in water)", CaloriesPer100g = 132 },
            new Food { Id = 38, Name = "Shrimp (boiled)", CaloriesPer100g = 99 },
            new Food { Id = 39, Name = "Tofu", CaloriesPer100g = 76 },
            new Food { Id = 40, Name = "Lentils (cooked)", CaloriesPer100g = 116 },
            new Food { Id = 41, Name = "Chickpeas (cooked)", CaloriesPer100g = 164 },
            new Food { Id = 42, Name = "Beans (black, cooked)", CaloriesPer100g = 132 },
            new Food { Id = 43, Name = "Oatmeal (cooked)", CaloriesPer100g = 68 },
            new Food { Id = 44, Name = "Almonds", CaloriesPer100g = 579 },
            new Food { Id = 45, Name = "Peanuts", CaloriesPer100g = 567 },
            new Food { Id = 46, Name = "Walnuts", CaloriesPer100g = 654 },
            new Food { Id = 47, Name = "Sunflower Seeds", CaloriesPer100g = 584 },
            new Food { Id = 48, Name = "Dark Chocolate (70-85%)", CaloriesPer100g = 598 },
            new Food { Id = 49, Name = "Honey", CaloriesPer100g = 304 },
            new Food { Id = 50, Name = "Jam", CaloriesPer100g = 250 }
        );


    }
}
