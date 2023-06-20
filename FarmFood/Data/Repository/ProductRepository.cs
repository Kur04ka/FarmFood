using FarmFood.Data.Interfaces;
using FarmFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FarmFood.Data.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly AppDBContext appDBContent;
        public ProductRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Product> AllProducts => appDBContent.Product.Include(c => c.Category);

        public Product getObjectProduct(int id) => appDBContent.Product.First(c => c.id == id);

        public IEnumerable<Product> AllAdvertisements(string sellerEmail) =>
            appDBContent.Product
            .Where(x => x.sellerEmail == sellerEmail)
            .ToList();
    }
}
