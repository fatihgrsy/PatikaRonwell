using Business.IServices;
using Models.Categories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Business.Services
{
    public class UnderCategoryService : IUnderCategory
    {
        public List<UnderCategory> GetAllUnderCategory()
        {
            string sqlQuery = @"Select * From UnderCategory";
            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<UnderCategory>(sqlQuery, null);
        }

        public UnderCategory GetSingleUnderCategory(int id)
        {
            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id", id);
            string sqlQuery = @"Select * From UnderCategory where Id=@Id";
            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<UnderCategory>(sqlQuery, parameter).FirstOrDefault();
        }

        public int UnderCategoryUpdate (UnderCategory model)
        {
            string sqlQuery = @"Update UnderCategory set CategoryId=@CategoryId,UnderCategoryName=@UnderCategoryName where Id=@Id";
            var parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@CategoryId", model.CategoryId);
            parameter[1] = new SqlParameter("@UnderCategoryName", model.UnderCategoryName);
            parameter[2] = new SqlParameter("@Id", model.Id);
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public int UnderCategoryDelete(int id)
        {
            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id", id);
            string sqlQuery = @"Delete From UnderCategory where Id=@Id";
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public int UnderCategoryAdd(UnderCategory model)
        {
            string sqlQuery = @"Insert Into UnderCategory (CategoryId,UnderCategoryName) values(@CategoryId,@UnderCategoryName)";
            var parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@CategoryId", model.CategoryId);
            parameter[1] = new SqlParameter("@UnderCategoryName", model.UnderCategoryName);
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }
    }
}
