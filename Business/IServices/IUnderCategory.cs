using Models.Categories;
using System.Collections.Generic;

namespace Business.IServices
{
    public interface IUnderCategory
    {
        int UnderCategoryAdd(UnderCategory model);
        int UnderCategoryUpdate(UnderCategory model);
        int UnderCategoryDelete(int id);
        List<UnderCategory> GetAllUnderCategory();
        UnderCategory GetSingleUnderCategory(int id);
    }
}
