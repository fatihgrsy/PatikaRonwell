using Models.Orders;
using System.Collections.Generic;

namespace Business.IServices
{
    public interface IOrder
    {
        int OrderAdd(Order model);
        int OrderUpdate(Order model);
        int OrderDelete(int id);
        List<Order> GetAllOrder();
        Order GetSingleOrder(int id);
    }
}
