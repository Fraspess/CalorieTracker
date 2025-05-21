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
                                         Data Source = (localdb)\MSSQLLocalDB;
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
            new Food { Id = 1, Name = "Apple", CaloriesPer100g = 52, CarbsPer100g = 14, ProteinPer100g = 0.3m, FatsPer100g = 0.2m },
            new Food { Id = 2, Name = "Banana", CaloriesPer100g = 96, CarbsPer100g = 27, ProteinPer100g = 1.2m, FatsPer100g = 0.3m },
            new Food { Id = 3, Name = "Orange", CaloriesPer100g = 47, CarbsPer100g = 12, ProteinPer100g = 0.9m, FatsPer100g = 0.1m },
            new Food { Id = 4, Name = "Strawberry", CaloriesPer100g = 32, CarbsPer100g = 8, ProteinPer100g = 0.7m, FatsPer100g = 0.3m },
            new Food { Id = 5, Name = "Grapes", CaloriesPer100g = 69, CarbsPer100g = 18, ProteinPer100g = 0.7m, FatsPer100g = 0.2m },
            new Food { Id = 6, Name = "Watermelon", CaloriesPer100g = 30, CarbsPer100g = 8, ProteinPer100g = 0.6m, FatsPer100g = 0.2m },
            new Food { Id = 7, Name = "Pineapple", CaloriesPer100g = 50, CarbsPer100g = 13, ProteinPer100g = 0.5m, FatsPer100g = 0.1m },
            new Food { Id = 8, Name = "Mango", CaloriesPer100g = 60, CarbsPer100g = 15, ProteinPer100g = 0.8m, FatsPer100g = 0.4m },
            new Food { Id = 9, Name = "Blueberry", CaloriesPer100g = 57, CarbsPer100g = 14, ProteinPer100g = 0.7m, FatsPer100g = 0.3m },
            new Food { Id = 10, Name = "Kiwi", CaloriesPer100g = 61, CarbsPer100g = 15, ProteinPer100g = 1.1m, FatsPer100g = 0.5m },
            new Food { Id = 11, Name = "Tomato", CaloriesPer100g = 18, CarbsPer100g = 4, ProteinPer100g = 0.9m, FatsPer100g = 0.2m },
            new Food { Id = 12, Name = "Cucumber", CaloriesPer100g = 16, CarbsPer100g = 4, ProteinPer100g = 0.7m, FatsPer100g = 0.1m },
            new Food { Id = 13, Name = "Carrot", CaloriesPer100g = 41, CarbsPer100g = 10, ProteinPer100g = 0.9m, FatsPer100g = 0.2m },
            new Food { Id = 14, Name = "Potato", CaloriesPer100g = 77, CarbsPer100g = 17, ProteinPer100g = 2.1m, FatsPer100g = 0.1m },
            new Food { Id = 15, Name = "Sweet Potato", CaloriesPer100g = 86, CarbsPer100g = 20, ProteinPer100g = 1.6m, FatsPer100g = 0.1m },
            new Food { Id = 16, Name = "Broccoli", CaloriesPer100g = 34, CarbsPer100g = 7, ProteinPer100g = 2.8m, FatsPer100g = 0.4m },
            new Food { Id = 17, Name = "Cauliflower", CaloriesPer100g = 25, CarbsPer100g = 5, ProteinPer100g = 1.9m, FatsPer100g = 0.3m },
            new Food { Id = 18, Name = "Spinach", CaloriesPer100g = 23, CarbsPer100g = 4, ProteinPer100g = 2.9m, FatsPer100g = 0.4m },
            new Food { Id = 19, Name = "Onion", CaloriesPer100g = 40, CarbsPer100g = 9, ProteinPer100g = 1.1m, FatsPer100g = 0.1m },
            new Food { Id = 20, Name = "Garlic", CaloriesPer100g = 149, CarbsPer100g = 33, ProteinPer100g = 6.4m, FatsPer100g = 0.5m },
            new Food { Id = 21, Name = "Lettuce", CaloriesPer100g = 15, CarbsPer100g = 3, ProteinPer100g = 1.4m, FatsPer100g = 0.2m },
            new Food { Id = 22, Name = "Peas", CaloriesPer100g = 81, CarbsPer100g = 14, ProteinPer100g = 5.4m, FatsPer100g = 0.4m },
            new Food { Id = 23, Name = "Corn", CaloriesPer100g = 86, CarbsPer100g = 19, ProteinPer100g = 3.2m, FatsPer100g = 1.2m },
            new Food { Id = 24, Name = "Rice (cooked)", CaloriesPer100g = 130, CarbsPer100g = 28, ProteinPer100g = 2.7m, FatsPer100g = 0.3m },
            new Food { Id = 25, Name = "Pasta (cooked)", CaloriesPer100g = 131, CarbsPer100g = 25, ProteinPer100g = 5.1m, FatsPer100g = 1.1m },
            new Food { Id = 26, Name = "Bread (white)", CaloriesPer100g = 265, CarbsPer100g = 49, ProteinPer100g = 9.2m, FatsPer100g = 3.2m },
            new Food { Id = 27, Name = "Bread (whole wheat)", CaloriesPer100g = 247, CarbsPer100g = 41, ProteinPer100g = 12.5m, FatsPer100g = 3.4m },
            new Food { Id = 28, Name = "Avocado", CaloriesPer100g = 160, CarbsPer100g = 9, ProteinPer100g = 2.0m, FatsPer100g = 14.7m },
            new Food { Id = 29, Name = "Beef (lean)", CaloriesPer100g = 250, CarbsPer100g = 0, ProteinPer100g = 26.1m, FatsPer100g = 15.3m },
            new Food { Id = 30, Name = "Chicken breast", CaloriesPer100g = 165, CarbsPer100g = 0, ProteinPer100g = 31.0m, FatsPer100g = 3.6m },
            new Food { Id = 31, Name = "Salmon", CaloriesPer100g = 208, CarbsPer100g = 0, ProteinPer100g = 20.4m, FatsPer100g = 13.4m },
            new Food { Id = 32, Name = "Eggs", CaloriesPer100g = 143, CarbsPer100g = 0.7m, ProteinPer100g = 12.6m, FatsPer100g = 9.5m },
            new Food { Id = 33, Name = "Milk (whole)", CaloriesPer100g = 60, CarbsPer100g = 4.8m, ProteinPer100g = 3.2m, FatsPer100g = 3.3m },
            new Food { Id = 34, Name = "Yogurt (natural)", CaloriesPer100g = 59, CarbsPer100g = 3.6m, ProteinPer100g = 3.5m, FatsPer100g = 3.3m },
            new Food { Id = 35, Name = "Cheese (cheddar)", CaloriesPer100g = 403, CarbsPer100g = 1.3m, ProteinPer100g = 24.9m, FatsPer100g = 33.1m },
            new Food { Id = 36, Name = "Butter", CaloriesPer100g = 717, CarbsPer100g = 0.1m, ProteinPer100g = 0.9m, FatsPer100g = 81.1m },
            new Food { Id = 37, Name = "Olive oil", CaloriesPer100g = 884, CarbsPer100g = 0, ProteinPer100g = 0, FatsPer100g = 100m },
            new Food { Id = 38, Name = "Almonds", CaloriesPer100g = 579, CarbsPer100g = 21.6m, ProteinPer100g = 21.2m, FatsPer100g = 49.9m },
            new Food { Id = 39, Name = "Walnuts", CaloriesPer100g = 654, CarbsPer100g = 13.7m, ProteinPer100g = 15.2m, FatsPer100g = 65.2m },
            new Food { Id = 40, Name = "Peanut butter", CaloriesPer100g = 588, CarbsPer100g = 20.0m, ProteinPer100g = 25.1m, FatsPer100g = 50.4m },
            new Food { Id = 41, Name = "Dark chocolate", CaloriesPer100g = 546, CarbsPer100g = 61.2m, ProteinPer100g = 4.9m, FatsPer100g = 31.3m },
            new Food { Id = 42, Name = "Honey", CaloriesPer100g = 304, CarbsPer100g = 82.4m, ProteinPer100g = 0.3m, FatsPer100g = 0m },
            new Food { Id = 43, Name = "Oatmeal", CaloriesPer100g = 68, CarbsPer100g = 12.0m, ProteinPer100g = 2.4m, FatsPer100g = 1.4m },
            new Food { Id = 44, Name = "Quinoa (cooked)", CaloriesPer100g = 120, CarbsPer100g = 21.3m, ProteinPer100g = 4.4m, FatsPer100g = 1.9m },
            new Food { Id = 45, Name = "Lentils (cooked)", CaloriesPer100g = 116, CarbsPer100g = 20.1m, ProteinPer100g = 9.0m, FatsPer100g = 0.4m },
            new Food { Id = 46, Name = "Chickpeas (cooked)", CaloriesPer100g = 164, CarbsPer100g = 27.4m, ProteinPer100g = 8.9m, FatsPer100g = 2.6m },
            new Food { Id = 47, Name = "Tofu", CaloriesPer100g = 76, CarbsPer100g = 1.9m, ProteinPer100g = 8.1m, FatsPer100g = 4.8m },
            new Food { Id = 48, Name = "Turkey breast", CaloriesPer100g = 135, CarbsPer100g = 0, ProteinPer100g = 29.6m, FatsPer100g = 1.7m },
            new Food { Id = 49, Name = "Pork chop", CaloriesPer100g = 242, CarbsPer100g = 0, ProteinPer100g = 27.3m, FatsPer100g = 14.4m },
            new Food { Id = 50, Name = "Shrimp", CaloriesPer100g = 99, CarbsPer100g = 0.2m, ProteinPer100g = 24.0m, FatsPer100g = 0.3m },
            new Food { Id = 51, Name = "Duck meat", CaloriesPer100g = 337, CarbsPer100g = 0, ProteinPer100g = 18.9m, FatsPer100g = 28.3m },
            new Food { Id = 52, Name = "Lamb chops", CaloriesPer100g = 294, CarbsPer100g = 0, ProteinPer100g = 25.2m, FatsPer100g = 20.9m },
            new Food { Id = 53, Name = "Bacon (fried)", CaloriesPer100g = 541, CarbsPer100g = 1.4m, ProteinPer100g = 37.0m, FatsPer100g = 41.8m },
            new Food { Id = 54, Name = "Sausage (pork)", CaloriesPer100g = 296, CarbsPer100g = 1.9m, ProteinPer100g = 12.3m, FatsPer100g = 26.1m },
            new Food { Id = 55, Name = "Ham (cooked)", CaloriesPer100g = 145, CarbsPer100g = 1.5m, ProteinPer100g = 18.3m, FatsPer100g = 6.8m },
            new Food { Id = 56, Name = "Tuna (canned in water)", CaloriesPer100g = 128, CarbsPer100g = 0, ProteinPer100g = 23.6m, FatsPer100g = 2.7m },
            new Food { Id = 57, Name = "Cod (baked)", CaloriesPer100g = 105, CarbsPer100g = 0, ProteinPer100g = 22.8m, FatsPer100g = 0.9m },
            new Food { Id = 58, Name = "Sardines (canned)", CaloriesPer100g = 208, CarbsPer100g = 0, ProteinPer100g = 24.6m, FatsPer100g = 11.5m },
            new Food { Id = 59, Name = "Mussels (steamed)", CaloriesPer100g = 172, CarbsPer100g = 7.4m, ProteinPer100g = 23.8m, FatsPer100g = 4.5m },
            new Food { Id = 60, Name = "Octopus (boiled)", CaloriesPer100g = 164, CarbsPer100g = 4.4m, ProteinPer100g = 29.8m, FatsPer100g = 2.1m },
            new Food { Id = 61, Name = "Cottage cheese", CaloriesPer100g = 98, CarbsPer100g = 3.4m, ProteinPer100g = 11.1m, FatsPer100g = 4.3m },
            new Food { Id = 62, Name = "Feta cheese", CaloriesPer100g = 264, CarbsPer100g = 4.1m, ProteinPer100g = 14.2m, FatsPer100g = 21.3m },
            new Food { Id = 63, Name = "Mozzarella", CaloriesPer100g = 280, CarbsPer100g = 3.1m, ProteinPer100g = 27.5m, FatsPer100g = 17.1m },
            new Food { Id = 64, Name = "Greek yogurt", CaloriesPer100g = 59, CarbsPer100g = 3.6m, ProteinPer100g = 10.2m, FatsPer100g = 0.4m },
            new Food { Id = 65, Name = "Sour cream", CaloriesPer100g = 193, CarbsPer100g = 4.3m, ProteinPer100g = 2.4m, FatsPer100g = 18.9m },
            new Food { Id = 66, Name = "Cashews", CaloriesPer100g = 553, CarbsPer100g = 30.2m, ProteinPer100g = 18.2m, FatsPer100g = 43.9m },
            new Food { Id = 67, Name = "Pistachios", CaloriesPer100g = 562, CarbsPer100g = 27.5m, ProteinPer100g = 20.3m, FatsPer100g = 45.4m },
            new Food { Id = 68, Name = "Pumpkin seeds", CaloriesPer100g = 559, CarbsPer100g = 10.7m, ProteinPer100g = 30.2m, FatsPer100g = 49.0m },
            new Food { Id = 69, Name = "Sunflower seeds", CaloriesPer100g = 584, CarbsPer100g = 20.0m, ProteinPer100g = 20.8m, FatsPer100g = 51.5m },
            new Food { Id = 70, Name = "Chia seeds", CaloriesPer100g = 486, CarbsPer100g = 42.1m, ProteinPer100g = 16.5m, FatsPer100g = 30.7m },
            new Food { Id = 71, Name = "Black beans (cooked)", CaloriesPer100g = 132, CarbsPer100g = 23.7m, ProteinPer100g = 8.9m, FatsPer100g = 0.5m },
            new Food { Id = 72, Name = "Kidney beans (cooked)", CaloriesPer100g = 127, CarbsPer100g = 22.8m, ProteinPer100g = 8.7m, FatsPer100g = 0.5m },
            new Food { Id = 73, Name = "Soybeans (cooked)", CaloriesPer100g = 173, CarbsPer100g = 9.9m, ProteinPer100g = 16.6m, FatsPer100g = 9.0m },
            new Food { Id = 74, Name = "Lima beans (cooked)", CaloriesPer100g = 115, CarbsPer100g = 20.9m, ProteinPer100g = 7.8m, FatsPer100g = 0.4m },
            new Food { Id = 75, Name = "Green peas (cooked)", CaloriesPer100g = 84, CarbsPer100g = 15.6m, ProteinPer100g = 5.4m, FatsPer100g = 0.2m },
            new Food { Id = 76, Name = "Buckwheat (cooked)", CaloriesPer100g = 92, CarbsPer100g = 19.9m, ProteinPer100g = 3.4m, FatsPer100g = 0.6m },
            new Food { Id = 77, Name = "Barley (cooked)", CaloriesPer100g = 123, CarbsPer100g = 28.2m, ProteinPer100g = 2.3m, FatsPer100g = 0.4m },
            new Food { Id = 78, Name = "Millet (cooked)", CaloriesPer100g = 119, CarbsPer100g = 23.7m, ProteinPer100g = 3.5m, FatsPer100g = 1.0m },
            new Food { Id = 79, Name = "Couscous (cooked)", CaloriesPer100g = 112, CarbsPer100g = 23.2m, ProteinPer100g = 3.8m, FatsPer100g = 0.2m },
            new Food { Id = 80, Name = "Bulgur (cooked)", CaloriesPer100g = 83, CarbsPer100g = 18.6m, ProteinPer100g = 3.1m, FatsPer100g = 0.2m },
            new Food { Id = 81, Name = "Orange juice", CaloriesPer100g = 45, CarbsPer100g = 10.4m, ProteinPer100g = 0.7m, FatsPer100g = 0.2m },
            new Food { Id = 82, Name = "Apple juice", CaloriesPer100g = 46, CarbsPer100g = 11.3m, ProteinPer100g = 0.1m, FatsPer100g = 0.1m },
            new Food { Id = 83, Name = "Coffee (black)", CaloriesPer100g = 0, CarbsPer100g = 0, ProteinPer100g = 0, FatsPer100g = 0 },
            new Food { Id = 84, Name = "Green tea", CaloriesPer100g = 0, CarbsPer100g = 0, ProteinPer100g = 0, FatsPer100g = 0 },
            new Food { Id = 85, Name = "Beer (regular)", CaloriesPer100g = 43, CarbsPer100g = 3.6m, ProteinPer100g = 0.5m, FatsPer100g = 0m }
        );
    }


    }
