using Models.Categories;
using System.Collections.Generic;

namespace Business.IServices
{
    public interface ICategory
    {
        int CategoryAdd(Category model);
        int CategoryUpdate(Category model);
        int CategoryDelete(int id);
        List<Category> GetAllCategory();
        Category GetSingleCategory(int id);

        void CategoryAddBulk(List<Category> list);
    }
}
