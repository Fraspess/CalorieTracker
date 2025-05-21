using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataBase.Entities
{
    public class Food
    {

        public Food()
        {
            FoodEntries = new HashSet<FoodEntry>();
        }
        public int Id { get; set; }

        public string? Name { get; set; }

        public int CaloriesPer100g { get; set; }

        public decimal CarbsPer100g { get; set; }

        public decimal ProteinPer100g { get; set; }

        public decimal FatsPer100g { get; set; }

        public IEnumerable<FoodEntry> FoodEntries { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {CaloriesPer100g}";
        }
    }
}
