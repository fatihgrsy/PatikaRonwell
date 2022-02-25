using Models.Customers;
using System.Collections.Generic;

namespace Business.IServices
{
   public  interface ICustomer
    {
        int CustomerAdd(Customer model);
        int CustomerUpdate(Customer model);
        int CustomerDelete(int id);
        List<Customer> GetAllCustomer();
        Customer GetSingleCustomer(int id);
    }
}
