using Web_App_Store.Data.Models;

namespace Web_App_Store.ViewModels
{
    public class GamesListViewModel
    {
        public IEnumerable<Game> AllGames { get; set; }
        public string CurrCategory { get; set; }
    }
}
