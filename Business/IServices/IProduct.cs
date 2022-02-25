using Models.Products;
using System.Collections.Generic;

namespace Business.IServices
{
    public interface IProduct
    {
        int ProductAdd(Product model);
        int ProductUpdate(Product model);
        int ProductDelete(int id);
        List<Product> GetAllProduct();
        Product GetSingleProduct(int id);
    }
}
