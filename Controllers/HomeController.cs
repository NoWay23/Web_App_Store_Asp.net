using Microsoft.AspNetCore.Mvc;
using Web_App_Store.Data.Interfaces;
using Web_App_Store.ViewModels;

namespace Web_App_Store.Controllers
{
	public class HomeController: Controller
	{
		private readonly IAllGames _gameRep;

		public HomeController(IAllGames gameRep)
		{
			_gameRep = gameRep;
		}

		public ViewResult Index()
		{
			var homeGames = new HomeViewModel
			{
				favGames = _gameRep.GetFavouriteGames
			};
			return View(homeGames);
		}
	}
}
