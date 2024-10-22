using Microsoft.EntityFrameworkCore;
using Web_App_Store.Data.Interfaces;
using Web_App_Store.Data.Models;

namespace Web_App_Store.Data.Repository
{
    public class GameRepository : IAllGames
    {
         private readonly AppDBContent appDBContent;

        public GameRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Game> Games => appDBContent.Games.Include(c => c.Category); // Получаем все обьекты

        public IEnumerable<Game> GetFavouriteGames => appDBContent.Games.Where(p => p.IsFavoutite).Include(c => c.Category); // Получаем объекты где IsFavourite = true

        public Game GetObjectCar(int gameId) => appDBContent.Games.FirstOrDefault(p => p.Id == gameId); // Получаем объект по ID

    }
}
