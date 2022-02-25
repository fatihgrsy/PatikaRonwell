using Business.IServices;
using Models.Categories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Business.Services
{
    public class CategoryService : ICategory
    {
        public int CategoryAdd(Category model)
        {
            try
            {
                var parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@Name", model.CategoryTypes);
                return DBAdoNet.BaseOperations.AdoBase.Execute(SQLQueryList.CategoryAdd(), parameter);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void CategoryAddBulk(List<Category> list)
        {
            DBAdoNet.BaseOperations.AdoBase.BulkInsert(list,"Category");
        }

        public int CategoryDelete(int id)
        {
            try
            {
                var parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@Id", id);
                return DBAdoNet.BaseOperations.AdoBase.Execute(SQLQueryList.CategoryDelete(), parameter);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public int CategoryUpdate(Category model)
        {
            try
            {
                var parameter = new SqlParameter[2];
                parameter[0] = new SqlParameter("@Name", model.CategoryTypes);
                parameter[1] = new SqlParameter("@Id", model.Id);
                return DBAdoNet.BaseOperations.AdoBase.Execute(SQLQueryList.CategoryUpdate(), parameter);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<Category> GetAllCategory()
        {
            try
            {
                string sqlQuery = @"Select * From Category";
                return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<Category>(sqlQuery, null);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Category GetSingleCategory(int id)
        {
            try
            {
                var parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@Id", id);
                string sqlQuery = @"Select * From Category where Id=@Id";
                return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<Category>(sqlQuery, parameter).FirstOrDefault();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
