using FarmFood.Data;
using FarmFood.Data.Interfaces;
using FarmFood.Data.Models;
using FarmFood.Data.Repository;
using FarmFood.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace FarmFood.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllProducts allProducts;
        private readonly ShopCart shopCart;
        public ShopCartController(IAllProducts allProducts, ShopCart shopCart)
        {
            this.allProducts = allProducts;
            this.shopCart = shopCart;
        }


        #region "Index - All products from the Cart"

        public IActionResult Index() // Вывод всех товаров из корзины
        {
            IEnumerable<ShopCartItem> items = shopCart.GetItemsFromCart();

            if (items.IsNullOrEmpty())
            {
                return RedirectToAction("EmptyCart");
            }
            else
            {
                return View(shopCart);
            }
        }

        #endregion


        #region "RedirectToCart(AddToCart); AddOne; RemoveOne; RemoveItem"

        public IActionResult redirectToCart(int id) // Переадресовывает нас в корзину 
        {
            var addingItem = allProducts.AllProducts.First(i => i.id == id);

            var IsProductInTheCart = shopCart.GetItemsFromCart().Find(i => i.product == addingItem);

            if (IsProductInTheCart == null)
            {
                shopCart.AddToCart(addingItem);
            }
            else if (IsProductInTheCart != null)
            {
                shopCart.PlusOne(addingItem);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddOne(int id)
        {
            shopCart.PlusOne(id);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveOne(int id)
        {
            shopCart.MinusOne(id);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveItem(int id)
        {
            shopCart.RemoveItem(id);
            return RedirectToAction("Index");
        }

        #endregion


        #region "Empty Functions - EmptyCart" 

        public IActionResult EmptyCart()
        {
            return View();
        }

        #endregion
    }
}
