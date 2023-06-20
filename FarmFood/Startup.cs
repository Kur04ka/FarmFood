using FarmFood.Data;
using FarmFood.Data.Interfaces;
using FarmFood.Data.Models;
using FarmFood.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FarmFood
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("DBsettings.json").Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => //CookieAuthenticationOptions
        {
            options.LoginPath = new PathString("/Account/Login");
        });

            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllProducts, ProductRepository>();
            services.AddTransient<IProductsCategory, CategoryRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // ���������� ��� �������� � ��������
            services.AddScoped(sp => ShopCart.GetCart(sp)); // ��� ������ ����� ������ �������

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage(); // ��������� ���������� �������� � ��������
            app.UseStatusCodePages(); //��������� ���������� ���� ���������
            app.UseStaticFiles(); // ��������� ���������� ����������� �����, �������� � �.�.
            app.UseSession();
            

            app.UseAuthentication();    // ��������������
            app.UseAuthorization();     // �����������

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Products/List/{categoryName?}", defaults: new { Controller = "Products", action = "List" });
                routes.MapRoute(name: "chooseCategory", template: "Products/NewAdvertisementInformation/{categoryName}");
                routes.MapRoute(name: "sellerEmail", template: "Products/LinkToSeller/{sellerEmail}");
            });
            
        }
    }
}
