using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_App_Store.Data.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; } // адррес картинки которую будме использовать
        public decimal Price { get; set; }
        public bool IsFavoutite { get; set; } // отображение в лучших товарах
        public bool Available { get; set; } // доступен ли товар и сколько его осталось

        // параметры для присвоения игры к определенной категории
        public int CategoryId { get; set; } // прикрипление к категории
        public virtual Category Category { get; set; } // для создания объекта текущей категории

    }
}
