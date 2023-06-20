using System.Collections.Generic;

namespace FarmFood.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string categoryName { get; set; }

        public List<Product> products { get; set; } // Одна категория может содержать в себе много товаров
    }
}
