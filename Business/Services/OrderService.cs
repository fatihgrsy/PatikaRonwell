using Business.IServices;
using Models.Orders;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Business.Services
{
    public class OrderService : IOrder
    {
        public List<Order> GetAllOrder()
        {

            string sqlQuery = "Select * From [Order]";
            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<Order>(sqlQuery, null);
        }

        public Order GetSingleOrder(int id)
        {
            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id", id);
            string sqlQuery = "Select * From [Order] where Id=@Id";

            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<Order>(sqlQuery, parameter).FirstOrDefault();
        }

        public int OrderAdd(Order model)
        {
            var parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@CustomerId", model.CustomerId);
            parameter[1] = new SqlParameter("@PriceTagId", model.PriceTagId);
            parameter[2] = new SqlParameter("@ProductId", model.ProductId);
            string sqlQuery = @"Insert into [Order] (CustomerId,PriceTagId,ProductId) values (@CustomerId,@PriceTagId,@ProductId)";
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public int OrderDelete(int id)
        {
            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id", id);
            string sqlQuery = "Delete From [Order] where Id=@Id";
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public int OrderUpdate(Order model)
        {
            var parameter = new SqlParameter[4];
            parameter[0] = new SqlParameter("@CustomerId", model.CustomerId);
            parameter[1] = new SqlParameter("@PriceTagId", model.PriceTagId);
            parameter[2] = new SqlParameter("@ProductId", model.ProductId);
            parameter[3] = new SqlParameter("@Id", model.Id);

            string sqlQuery = @"Update [Order] set CustomerId=@CustomerId,PriceTagId=@PriceTagId,ProductId=@ProductId where Id=@Id";
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }
    }
}
