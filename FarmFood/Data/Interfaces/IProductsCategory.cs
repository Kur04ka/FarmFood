using FarmFood.Data.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Collections;
using System.Collections.Generic;

namespace FarmFood.Data.Interfaces
{
    public interface IProductsCategory
    {
        IEnumerable<Category> AllCategories { get; } // возвращает все категории из модели Category
    }
}
