using Web_App_Store.Data.Models;

namespace Web_App_Store.Data.Interfaces
    {
        public interface IGamesCategory
        {
            IEnumerable<Category> AllCategories { get; }
        }
}
