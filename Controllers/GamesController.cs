using Microsoft.AspNetCore.Mvc;
using Web_App_Store.Data.Interfaces;
using Web_App_Store.Data.Models;
using Web_App_Store.ViewModels;

namespace Web_App_Store.Controllers
{

    //  Контроллер обрабатывает данные запроса и посылает обратно результат обработки.
    //  Функции возвращающие VieResult, который идет в виде httml страницы
    public class GamesController : Controller
    {
        private readonly IAllGames allGames;
        private IGamesCategory gamesCategories;

        public GamesController(IAllGames allGames, IGamesCategory gamesCategories)
        {
            this.allGames = allGames;
            this.gamesCategories = gamesCategories;
        }

        [Route("Games/List")]
        [Route("Games/List/{category}")]
        public ViewResult List(string category) // возвращает список всех товаров
        {
            string _category = category;
            IEnumerable<Game> games = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                games = allGames.Games.OrderBy(i => i.Id);

            }
            else
            {
                if (string.Equals("Shooter", category, StringComparison.OrdinalIgnoreCase))
                {
                    games = allGames.Games.Where(i => i.Category.Name.Equals("Шутеры")).OrderBy(i => i.Id);
                    currCategory = "Шутеры";
                }
                else if(string.Equals("Slasher", category, StringComparison.OrdinalIgnoreCase))
                {
                    games = allGames.Games.Where(i => i.Category.Name.Equals("Слэшеры")).OrderBy(i => i.Id);
                    currCategory = "Слэшеры";
                }
                else if (string.Equals("Survival", category, StringComparison.OrdinalIgnoreCase))
                {
                    games = allGames.Games.Where(i => i.Category.Name.Equals("Выживание")).OrderBy(i => i.Id);
                    currCategory = "Выживание";
                }
                else if (string.Equals("Simulator", category, StringComparison.OrdinalIgnoreCase))
                {
                    games = allGames.Games.Where(i => i.Category.Name.Equals("Симуляторы")).OrderBy(i => i.Id);
                    currCategory = "Симуляторы";
                }
            }

            var gameObj = new GamesListViewModel
            {
                AllGames = games,
                CurrCategory = currCategory
            };


            ViewBag.Title = "Страница с играми";

            return View(gameObj);           // некая html страница 
        }


    }
}
