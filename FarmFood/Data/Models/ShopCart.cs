using FarmFood.Data.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FarmFood.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContext db;
        public ShopCart(AppDBContext db)
        {
            this.db = db;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopCartItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services) // Если человек добавлял товар в корзину, то ок, если нет - создаем новую
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // Создали переменную, с помощью которой мы можем работать с сессией
            var context = services.GetService<AppDBContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString(); // В переменную устанавливаем значение из сессии, а если его нет, то мы создаем новую строку
            session.SetString("CartId", shopCartId); // Устанавливаем ID корзины
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Product product) // Сам объект и его  добавление
        {
            db.ShopCartItem.Add(new ShopCartItem
            {
                product = product,
                shopCartID = ShopCartId,
                quantity = 1
            });
            db.SaveChanges();
        }

        public List<ShopCartItem> GetItemsFromCart() // Возвращает все товары из корзины
        {
            return db.ShopCartItem
                .Where(x => x.shopCartID == ShopCartId)
                .Include(x => x.product)
                .ToList();
        }

        #region "Interaction with ShopCartItem"

        public void PlusOne(Product product)
        {
            ShopCartItem shopCartItem = db.ShopCartItem.First(i => i.shopCartID == ShopCartId && i.product == product);
            shopCartItem.quantity++;

            db.Entry(shopCartItem).State = EntityState.Modified;

            db.SaveChanges();
        }

        public void PlusOne(int id)
        {
            ShopCartItem shopCartItem = db.ShopCartItem.First(i => i.id == id);
            shopCartItem.quantity++;

            db.Entry(shopCartItem).State = EntityState.Modified;

            db.SaveChanges();
        }

        public void MinusOne(int id)
        {
            ShopCartItem shopCartItem = db.ShopCartItem.First(i => i.id == id);
            shopCartItem.quantity--;
            if (shopCartItem.quantity == 0)
            {
                db.Remove(shopCartItem);

                db.SaveChanges();
            }
            else
            {
                db.Entry(shopCartItem).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void RemoveItem(int id)
        {
            ShopCartItem shopCartItem = db.ShopCartItem.First(i => i.id == id);

            db.Remove(shopCartItem);

            db.SaveChanges();
        }

        #endregion

    }
}
