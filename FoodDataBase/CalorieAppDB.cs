using FoodDataBase.Entities;
using Microsoft.EntityFrameworkCore;

public class CalorieAppDB : DbContext
{
    public DbSet<Food> Foods { get; set; }
    
    public DbSet<FoodEntry> FoodEntries { get; set; }

    public DbSet<User> Users { get; set; }

    public CalorieAppDB()
    {

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
            new Food { Id = 2, Name = "Banana", CaloriesPer100g = 96 }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Gmail = "pavlosamchyk@gmail.com", PasswordHash = "Test1234" }
            );

    }
}
