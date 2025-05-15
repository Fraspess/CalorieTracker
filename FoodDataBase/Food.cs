using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataBase
{
    public class Food
    {
        public int FoodId { get; set; }
        public string? FoodName { get; set; }
        public int CaloriesPer100g { get; set; }
        public string? CodeLink { get; set; }
    }
}
