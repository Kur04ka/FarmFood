using FarmFood.Data.Models;
using System.Collections.Generic;

namespace FarmFood.ViewModels.Products
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; } // Получаем все товары

        public string currentCategory { get; set; } // Текущая категория ( с которой мы сейчас работаем )
    }
}
