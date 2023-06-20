using FarmFood.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace FarmFood.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> AllProducts { get; } // Возвращает список всех товаров

        IEnumerable<Product> AllAdvertisements(string sellerEmail);

        Product getObjectProduct (int productId); // Возвращает конкретный товар по его ID
    }
}
