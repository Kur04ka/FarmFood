using FarmFood.Data;
using FarmFood.Data.Interfaces;
using FarmFood.Data.Models;
using FarmFood.ViewModels.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FarmFood.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts allProducts;
        private readonly AppDBContext db;
        private IHostingEnvironment environment;
        public ProductsController(IAllProducts allProducts, AppDBContext db, IHostingEnvironment environment)
        {
            this.allProducts = allProducts;
            this.db = db;
            this.environment = environment;
        }


        #region "Вывод всех товаров и товаров по категориям"

        [Route("Products/List")]
        [Route("Products/List/{categoryName}")]
        public ViewResult List(string categoryName) // Возвращает все товары
        {
            string _categoryName = categoryName;
            string currentCategory = null;
            IEnumerable<Product> products = null;
            if (string.IsNullOrEmpty(_categoryName))
            {
                currentCategory = "Все товары";
                products = allProducts.AllProducts.OrderBy(i => i.id);
            }
            else
            {
                #region "Категории"

                if (string.Equals("DairyProducts", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Молоко, сыр, яйца";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Молоко, сыр, яйца")).OrderBy(i => i.id);
                }
                else if (string.Equals("MeatProducts", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Мясная продукция";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Мясная продукция")).OrderBy(i => i.id);
                }
                else if (string.Equals("FishAndSeafood", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Рыба, морепродукты";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Рыба, морепродукты")).OrderBy(i => i.id);
                }
                else if (string.Equals("FruitsAndBerries", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Фрукты, ягоды, бахчевые";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Фрукты, ягоды, бахчевые")).OrderBy(i => i.id);
                }
                else if (string.Equals("SemifinishedProducts", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Полуфабрикаты";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Полуфабрикаты")).OrderBy(i => i.id);
                }
                else if (string.Equals("Mushrooms", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Грибы";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Грибы")).OrderBy(i => i.id);
                }
                else if (string.Equals("Honey", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Мёд";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Мёд")).OrderBy(i => i.id);
                }
                else if (string.Equals("CannedFood", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Консервированные продукты";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Консервированные продукты")).OrderBy(i => i.id);
                }
                else if (string.Equals("CerealsAndFlour", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Крупы, мука";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Крупы, мука")).OrderBy(i => i.id);
                }
                else if (string.Equals("KitchenHerbsAndSpices", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Травы и пряности";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Травы и пряности")).OrderBy(i => i.id);
                }
                else if (string.Equals("Confectionery", _categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    currentCategory = "Кондитерские изделия";
                    products = allProducts.AllProducts.Where(i => i.categoryName.Equals("Кондитерские изделия")).OrderBy(i => i.id);
                }

                #endregion
            }
            var productObject = new ProductsListViewModel
            {
                AllProducts = products,
                currentCategory = currentCategory
            };
            return View(productObject);
        }

        #endregion


        #region "Добавление нового товара"

        public IActionResult NewAdvertisementCategory()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult NewAdvertisementInformation()
        {
            return View();
        }

        [HttpPost]
        [Route("Products/NewAdvertisementInformation/{categoryName}")]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> NewAdvertisementInformation(NewAdvertisementInformationViewModel model, string categoryName, List<IFormFile> postedFiles)
        {
            User user = db.User.First(u => u.Email == User.Identity.Name);
            string _categoryName = categoryName;

            #region "Категории"


            if (string.Equals("DairyProducts", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Молоко, сыр, яйца";
            }
            else if (string.Equals("MeatProducts", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Мясная продукция";
            }
            else if (string.Equals("FishAndSeafood", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Рыба, морепродукты";
            }
            else if (string.Equals("FruitsAndBerries", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Фрукты, ягоды, бахчевые";
            }
            else if (string.Equals("SemifinishedProducts", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Полуфабрикаты";
            }
            else if (string.Equals("Mushrooms", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Грибы";
            }
            else if (string.Equals("Honey", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Мёд";
            }
            else if (string.Equals("CannedFood", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Консервированные продукты";
            }
            else if (string.Equals("CerealsAndFlour", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Крупы, мука";
            }
            else if (string.Equals("KitchenHerbsAndSpices", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Травы и пряности";
            }
            else if (string.Equals("Confectionery", _categoryName, StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Кондитерские изделия";
            }

            #endregion

            string wwwPath = environment.WebRootPath;
            string path = Path.Combine(environment.WebRootPath, "img");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    db.Product.Add(new Product
                    {
                        categoryName = categoryName,
                        name = model.productName,
                        desc = model.productDescription,
                        quantity = model.productQuantity,
                        price = model.productPrice,
                        unitOfMeasure = model.unitOfMeasure,
                        img = "/img/" + fileName,
                        sellerEmail = user.Email,
                        cityOfOrigin = user.CityOfResidence,
                        sellerName = user.FirstName + ' ' + user.LastName,
                        dateOfRegistration = DateTime.Now.Date.ToShortDateString()
                    }); ;

                    await db.SaveChangesAsync();
                }
            }

            return Redirect("/Products/AllMyAdvertisements");
        }


        #endregion


        #region "Вывод рекламных объявлений"

        public IActionResult AllMyAdvertisements()
        {
            var items = allProducts.AllAdvertisements(User.Identity.Name);
            if (items.IsNullOrEmpty())
            {
                return RedirectToAction("EmptyAdvertisements");
            }
            else
            {
                return View(items);
            }
        }

        [Route("Products/LinkToSeller/{sellerEmail}")]
        public async Task<IActionResult> LinkToSeller(string sellerEmail)
        {
            User user = await db.User.FirstAsync(u => u.Email == sellerEmail);
            var products = allProducts.AllAdvertisements(sellerEmail);
            LinkToSellerViewModel model = new LinkToSellerViewModel()
            {
                user = user,
                products = products
            };
            return View(model);
        }

        public IActionResult EmptyAdvertisements()
        {
            return View();
        }

        #endregion


        #region "Информация о продукте"

        public IActionResult ProductInformation(int id)
        {
            var productObject = allProducts.getObjectProduct(id);
            return View(productObject);
        }


        #endregion


    }
}
