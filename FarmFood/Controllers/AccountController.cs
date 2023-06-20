using FarmFood.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FarmFood.Data;
using Microsoft.EntityFrameworkCore;
using FarmFood.ViewModels.Authorization;
using FarmFood.Data.Helper;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using FarmFood.ViewModels.PersonalProfile;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace FarmFood.Controllers
{
    public class AccountController : Controller
    {
        private AppDBContext db;
        public AccountController(AppDBContext context)
        {
            db = context;
        }


        #region "Personal Profile"
        [Authorize]
        public async Task<IActionResult> PersonalProfile()
        {
            User user = await db.User.FirstAsync(u => u.Email == User.Identity.Name);
            return View(user);
        }
        #endregion


        #region "Editing Profile"

        [HttpGet]
        public async Task<IActionResult> EditingProfile()
        {
            User user = await db.User.FirstAsync(u => u.Email == User.Identity.Name);
            EditingProfileViewModel model = new EditingProfileViewModel()
            {
                FullName = user.FirstName + ' ' + user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CityOfResidence = user.CityOfResidence,
                WhatsApp = user.WhatsApp,
                VKontakte = user.VKontakte,
                Telegram = user.Telegram
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditingProfile(EditingProfileViewModel model)
        {
            User user = await db.User.FirstAsync(u => u.Email == User.Identity.Name);
            user.FirstName = ReturnSplittedName(model.FullName)[0];
            user.LastName = ReturnSplittedName(model.FullName)[1];
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.CityOfResidence = model.CityOfResidence;
            user.WhatsApp = model.WhatsApp;
            user.VKontakte = model.VKontakte;
            user.Telegram = model.Telegram;

            db.Entry(user).State = EntityState.Modified;

            await db.SaveChangesAsync();

            return RedirectToAction("PersonalProfile");
        }

        #endregion


        #region "Login"

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.User.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == HashPasswordHelper.HashPassword(model.Password));
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        #endregion


        #region "Register"

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    db.User.Add(new User
                    {
                        Email = model.Email,
                        Password = HashPasswordHelper.HashPassword(model.Password),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = ConvertPhoneNumber(model.PhoneNumber)
                    });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login");
                    // TODO: Доделать атрибуты
                    //ModelState.AddModelError("Email", "Некорректные логин и(или) пароль");
                }
            }
            return View(model);
        }

        #endregion


        #region "Supporting Functions: Authenticate, Logout, ConvertPhoneNumber, ReturnSplittedName"
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


        public string ConvertPhoneNumber(string str)
        {
            ;
            var output = Regex.Replace(str, @"(?:\+7|8)?(?:\()?(\d{3})(?:\))?(\d{3})(?:-)?(\d{2})(?:-)?(\d{2})", "+7($1)$2-$3-$4");
            return output;
        }

        public string[] ReturnSplittedName(string fullname)
        {
            string[] splittedName = fullname.Split(' ');
            return splittedName;
        }

        #endregion


    }
}
