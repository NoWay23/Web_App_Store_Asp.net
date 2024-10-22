namespace Web_App_Store.Data.Models
{
    public class Category // категории товаров в магазине
    {
        public int Id { get; set; } 
        public string Name { get; set; } // имя категории
        public string Description { get; set; } // описание категории
        public List<Game>  Games { get; set; } // список игр, входящих в категорию
    }
}
