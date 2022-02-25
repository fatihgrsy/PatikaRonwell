using Business.IServices;
using Models.CustomerCarts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Business.Services
{
    public class CustomerCartService : ICustomerCart
    {
        public int CustomerCartAdd(CustomerCart model)
        {
            string sqlQuery = @" Insert Into CustomerCart (UnderCategoryId) Values (@UnderCategoryId)";

            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@UnderCategoryId", model.UnderCategoryId);

            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public int CustomerCartDelete(int id)
        {
            string sqlQuery = @"Delete From CustomerCart where Id=@Id";

            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id",id);

            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public int CustomerCartUpdate(CustomerCart model)
        {
            string sqlQuery = @"Update CustomerCart set UnderCategoryId=@UnderCategoryId where Id=@Id";

            var parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@UnderCategoryId", model.UnderCategoryId);
            parameter[1] = new SqlParameter("@Id", model.Id);
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public List<CustomerCart> GetAllCustomerCart()
        {
            string sqlQuery = @"Select * From CustomerCart ";
            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<CustomerCart>(sqlQuery, null);
        }

        public CustomerCart GetSingleCustomerCart(int id)
        {
            string sqlQuery = @"Select * From CustomerCart where Id=@Id";

            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id", id);

            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<CustomerCart>(sqlQuery, parameter).FirstOrDefault();
        }
    }
}
