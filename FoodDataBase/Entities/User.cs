using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataBase.Entities
{
    public class User
    {
        public User()
        {
            FoodEntries = new HashSet<FoodEntry>();
        }
        public int Id { get; set; }

        public string? Gmail { get; set; }

        public string? PasswordHash { get; set; }

        public IEnumerable<FoodEntry> FoodEntries { get; set; }
    }
}
