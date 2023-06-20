using FarmFood.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace FarmFood.ViewModels.Products
{
    public class LinkToSellerViewModel
    {
        public User user { get; set; }

        public IEnumerable<Product> products { get; set; }
    }
}
