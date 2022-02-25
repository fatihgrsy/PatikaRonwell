using Business.IServices;
using Models.PriceTags;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Business.Services
{
    public class PriceTagService : IPriceTag
    {
        public List<PriceTag> GetAllPriceTag()
        {
            string sqlQuery = @"Select * From PriceTag";
            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<PriceTag>(sqlQuery, null);
        }

        public PriceTag GetSinglePriceTag(int id)
        {
            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id", id);
            string sqlQuery = @"Select * From PriceTag where Id=@Id";
            return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<PriceTag>(sqlQuery, parameter).FirstOrDefault();
        }

        public int PriceTagAdd(PriceTag model)
        {
            string sqlQuery = @"Insert Into PriceTag (CategoryId,Price) values (@CategoryId,@Price)";
            var parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@CategoryId", model.CategoryId);
            parameter[1] = new SqlParameter("@Price", model.Price);
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public int PriceTagDelete(int id)
        {
            var parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@Id", id);
            string sqlQuery = @"Delete From PriceTag where Id=@Id";
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }

        public int PriceTagUpdate(PriceTag model)
        {
            string sqlQuery = @"Update PriceTag set CategoryId=@CategoryId,Price=@Price where Id=@Id";
            var parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@CategoryId", model.CategoryId);
            parameter[1] = new SqlParameter("@Price", model.Price);
            parameter[2] = new SqlParameter("@Id", model.Id);
            return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
        }
    }
}
