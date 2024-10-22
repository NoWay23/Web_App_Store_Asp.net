using Microsoft.Identity.Client;
using Web_App_Store.Data.Models;

namespace Web_App_Store.Data
{
    public class DBObjects
    {
        public static Dictionary<string, Category> category;


        public static void Initial(AppDBContent content) // добавляет объекты в базу данных
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Games.Any())
            {
                content.AddRange(
                    new Game
                    {
                        Name = "Call of Duty",
                        ShortDescription = "Популярный шутер",
                        LongDescription = "Компьютерная игра в жанре шутер от первого лица на тему Второй мировой войны, первая игра в одноимённой серии.",
                        Image = "/img/Call_of_Duty_img.jpeg",
                        Price = 799,
                        IsFavoutite = true,
                        Available = true,
                        Category = Categories["Шутеры"]
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
                        Category = Categories["Слэшеры"]
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
                        Category = Categories["Выживание"]
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
                        Category = Categories["Симуляторы"]
                    }
                    );
            }

            content.SaveChanges();
        }

        public static Dictionary<string, Category> Categories
        { 
            get 
            {
                if (category == null)
                {
                    var list = new Category[]
                        {
                            new Category { Name = "Шутеры", Description = "Шутеры позволяют игрокам использовать в своих действиях оружие, обычно с целью уничтожить врагов или противоборствующих игроков." },
                            new Category { Name = "Слэшеры", Description = "Игры этого жанра, как правило, динамичны, наполнены толпами врагов и огромным выбором оружия, которым можно в буквальном смысле рубить и кромсать все на своем пути." },
                            new Category { Name = "Выживание", Description = "Игроки получают возможности и ресурсы для создания инструментов, оружия и укрытий с целью выжить максимально долго." },
                            new Category { Name = "Симуляторы", Description = "Жанр видеоигр, который, в полном соответствии со своим названием, симулирует процесс управления каким-либо транспортом, механизмом, существом, поселением, планетой и так далее. " }
                        };

                    category = new Dictionary<string, Category>();

                    foreach (Category item in list)
                    {
                        category.Add(item.Name, item);
                    }

                }

                return category;
            }  
        }
    }
}
