using Web_App_Store.Data.Models;

namespace Web_App_Store.Data.Interfaces
{
    public interface IAllGames
    {
        IEnumerable<Game> Games { get; } 
        IEnumerable<Game> GetFavouriteGames { get; } // возвращает любимые товары
        Game GetObjectCar(int gameId); // по id
    }
}
