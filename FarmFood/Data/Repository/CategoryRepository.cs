using FarmFood.Data.Interfaces;
using FarmFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FarmFood.Data.Repository
{
    public class CategoryRepository : IProductsCategory
    {
        private readonly AppDBContext appDBContent;
        public CategoryRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category.ToList();
    }
}
