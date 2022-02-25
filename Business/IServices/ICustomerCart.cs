using Models.CustomerCarts;
using System.Collections.Generic;

namespace Business.IServices
{
    public interface ICustomerCart
    {
        int CustomerCartAdd(CustomerCart model);
        int CustomerCartUpdate(CustomerCart model);
        int CustomerCartDelete(int id);
        List<CustomerCart> GetAllCustomerCart();
        CustomerCart GetSingleCustomerCart(int id);
    }
}
