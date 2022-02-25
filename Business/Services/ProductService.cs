using Business.IServices;
using Models.Products;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Business.Services
{
    public class ProductService : IProduct
    {
        public List<Product> GetAllProduct()
        {
            string sqlQuery = @"Select * From Product";
            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<Product>(sqlQuery, null);
        }

        public Product GetSingleProduct(int id)
        {
            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id", id);

            string sqlQuery = @"Select * From Product where Id=@Id";
            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<Product>(sqlQuery, parameter).FirstOrDefault();
        }

        public int ProductAdd(Product model)
        {
            try
            {
                var parameter = new SqlParameter[5];
                parameter[0] = new SqlParameter("@ModelState", model.ModelState);
                parameter[1] = new SqlParameter("@InsertDate", model.InsertDate);
                parameter[2] = new SqlParameter("@UpdateDate", model.UpdateDate);
                parameter[3] = new SqlParameter("@ProductName", model.ProductName);
                parameter[4] = new SqlParameter("@UnderCategoryTypeId", model.UnderCategoryTypeId);

                string sqlQuery = @"INSERT INTO Product
                               (ModelState
                               ,InsertDate
                               ,UpdateDate
                               ,ProductName
                               ,UnderCategoryTypeId)
                         VALUES
                               (@ModelState
                               ,@InsertDate
                               ,@UpdateDate
                               ,@ProductName
                               ,@UnderCategoryTypeId)";
                return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public int ProductDelete(int id)
        {
            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id", id);

            string sqlQuery = @"Delete From Product where Id=@Id";
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public int ProductUpdate(Product model)
        {
            var parameter = new SqlParameter[6];
            parameter[0] = new SqlParameter("@ModelState", model.ModelState);
            parameter[1] = new SqlParameter("@InsertDate", model.InsertDate);
            parameter[2] = new SqlParameter("@UpdateDate", model.UpdateDate);
            parameter[3] = new SqlParameter("@ProductName", model.ProductName);
            parameter[4] = new SqlParameter("@UnderCategoryTypeId", model.UnderCategoryTypeId);
            parameter[5] = new SqlParameter("@Id", model.Id);

            string sqlQuery = @"Update Product
                               set ModelState=@ModelState
                               ,InsertDate=@InsertDate
                               ,UpdateDate=@UpdateDate
                               ,ProductName=@ProductName
                               ,UnderCategoryTypeId=@UnderCategoryTypeId where Id=@Id";
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }
    }
}
