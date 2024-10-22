using Web_App_Store.Data;
using Web_App_Store.Data.Interfaces;
using Web_App_Store.Data.Mocks;
using Web_App_Store.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Web_App_Store.Data.Models;

namespace Web_App_Store
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv) 
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build(); // получение файла db
        }

        //Этот метод вызывается во время выполнения.Используйте этот метод для добавления служб в контейнер.Служит для регистрации различных модулей, плагинов внутри нашего проекта
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllGames, GameRepository>();                   // позволяет объединять интерфейс и класс, который реализует данный интерфейс 
            services.AddTransient<IGamesCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();                                               // MVC — это шаблон программирования, который позволяет разделить логику приложения на три части: Model, View, Controller
            services.AddMvc(option => option.EnableEndpointRouting = false); // чтобы не ругалось VS посоветовало сделать так

            services.AddMemoryCache();
            services.AddSession();
        }

        // Используйте этот метод для настройки конвейера http-запросоd.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment)
        {
            app.UseDeveloperExceptionPage();      // отображение страницы с ошибками
            app.UseStatusCodePages();             // Коды ошибок страниицы
            app.UseStaticFiles();                 // использование статических файлов
            app.UseSession();
            app.UseMvcWithDefaultRoute();         // Для использования Url по умолчанию, если не указали сами
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller-Home}/{action-Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Game/{action}/{category?}", defaults: new { Controller = "Game", action = "List" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
