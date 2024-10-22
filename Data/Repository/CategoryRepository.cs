using Web_App_Store.Data.Interfaces;
using Web_App_Store.Data.Models;

namespace Web_App_Store.Data.Repository
{
    public class CategoryRepository : IGamesCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
