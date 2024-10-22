using System.Security.AccessControl;
using Web_App_Store.Data.Interfaces;
using Web_App_Store.Data.Models;

namespace Web_App_Store.Data.Mocks
{
    // Mock-объект (от англ. mock object, букв. — «объект-пародия», «объект-имитация», а также «подставка») — в объектно-ориентированном программировании — тип объектов, реализующих заданные аспекты моделируемого программного окружения.
    public class MockGames : IAllGames
    {
        private readonly IGamesCategory CategoryCars = new MockCategory(); // переменная с помощью которой можно указывать к какой категории принадлежит игра


        public IEnumerable<Game> Games // записываем какие у нас есть игры
        {
            get
            {
                return new List<Game> 
                {
                    new Game  
                    { 
                        Name = "Call of Duty", 
                        ShortDescription = "Популярный шутер", 
                        LongDescription = "Компьютерная игра в жанре шутер от первого лица на тему Второй мировой войны, первая игра в одноимённой серии.", 
                        Image = "/img/Call_of_Duty_img.jpeg", 
                        Price = 799, 
                        IsFavoutite = true, 
                        Available = true, 
                        Category = CategoryCars.AllCategories.ElementAt(0)
                    },
                    new Game 
                    {
                        Name = "Devil May Cry 5",
                        ShortDescription = "Популярный и всемилюбимый слэшер",
                        LongDescription = "компьютерная игра в жанре слэшер, разработанная и изданная японской компанией Capcom. Пятая игра основной оригинальной серии Devil May Cry и шестая часть франшизы.",
                        Image = "/img/DevilImg.jpeg", 
                        Price = 1799,
                        IsFavoutite = true, 
                        Available = true,
                        Category = CategoryCars.AllCategories.ElementAt(1)
                    },
                    new Game
                    {
                        Name = "Resident Evil 2",
                        ShortDescription = "Известная игра про хорор выживание",
                        LongDescription = "Компьютерная игра в жанре survival horror, разработанная Capcom R&D Division 1 и изданная Capcom 25 января 2019 года для PlayStation 4, Xbox One и Windows.",
                        Image = "/img/RE2.3.jpg",
                        Price = 2490,
                        IsFavoutite = true, 
                        Available = true,
                        Category = CategoryCars.AllCategories.ElementAt(2)
                    },
                    new Game
                    {
                        Name = "World of Tanks",
                        ShortDescription = "Игра для любителей танков",
                        LongDescription = "World of Tanks — это танковый симулятор с более чем 600 бронированными машинами, 11 нациями и 5 классами техники.",
                        Image = "/img/WOT3.jpg", 
                        Price = 999,
                        IsFavoutite = true, 
                        Available = true,
                        Category = CategoryCars.AllCategories.ElementAt(3)
                    }
                };
            }
        }


        public IEnumerable<Game> GetFavouriteGames { get; set; }

        public Game GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
