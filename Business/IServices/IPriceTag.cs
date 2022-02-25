using Models.PriceTags;
using System.Collections.Generic;

namespace Business.IServices
{
    public interface IPriceTag
    {
        int PriceTagAdd(PriceTag model);
        int PriceTagUpdate(PriceTag model);
        int PriceTagDelete(int id);
        List<PriceTag> GetAllPriceTag();
        PriceTag GetSinglePriceTag(int id);
    }
}
