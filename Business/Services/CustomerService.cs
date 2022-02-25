using Business.IServices;
using Models.Customers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Business.Services
{
    public class CustomerService : ICustomer
    {
        public int CustomerAdd(Customer model)
        {
            try
            {
                var parameter = new SqlParameter[12];
                parameter[0] = new SqlParameter("@ModelState", model.ModelState);
                parameter[1] = new SqlParameter("@InsertDate", model.InsertDate);
                parameter[2] = new SqlParameter("@UpdateDate", model.UpdateDate);
                parameter[3] = new SqlParameter("@NameSurname", model.NameSurname);
                parameter[4] = new SqlParameter("@Age", model.Age);
                parameter[5] = new SqlParameter("@GSMNumber", model.GSMNumber);
                parameter[6] = new SqlParameter("@EMail", model.EMail);
                parameter[7] = new SqlParameter("@City", model.City);
                parameter[8] = new SqlParameter("@Distirict", model.Distirict);
                parameter[9] = new SqlParameter("@Neighborhood", model.Neighborhood);
                parameter[10] = new SqlParameter("@Street", model.Street);
                parameter[11] = new SqlParameter("@BuildingNumber", model.BuildingNumber);
                string sqlQuery = @"INSERT INTO Customer
                                                   (ModelState
                                                   ,InsertDate
                                                   ,UpdateDate
                                                   ,NameSurname
                                                   ,Age
                                                   ,GSMNumber
                                                   ,EMail
                                                   ,City
                                                   ,Distirict
                                                   ,Neighborhood
                                                   ,Street
                                                   ,BuildingNumber)
                                             VALUES
                                                   (@ModelState
                                                   ,@InsertDate
                                                   ,@UpdateDate
                                                   ,@NameSurname
                                                   ,@Age
                                                   ,@GSMNumber
                                                   ,@EMail
                                                   ,@City
                                                   ,@Distirict
                                                   ,@Neighborhood
                                                   ,@Street
                                                   ,@BuildingNumber)";
                return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CustomerDelete(int id)
        {
            try
            {
                var parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@Id", id);
                string sqlQuery = @"Delete From Customer where Id=@Id";
                return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CustomerUpdate(Customer model)
        {
            try
            {
                var parameter = new SqlParameter[13];
                parameter[0] = new SqlParameter("@ModelState", model.ModelState);
                parameter[1] = new SqlParameter("@InsertDate", model.InsertDate);
                parameter[2] = new SqlParameter("@UpdateDate", model.UpdateDate);
                parameter[3] = new SqlParameter("@NameSurname", model.NameSurname);
                parameter[4] = new SqlParameter("@Age", model.Age);
                parameter[5] = new SqlParameter("@GSMNumber", model.GSMNumber);
                parameter[6] = new SqlParameter("@EMail", model.EMail);
                parameter[7] = new SqlParameter("@City", model.City);
                parameter[8] = new SqlParameter("@Distirict", model.Distirict);
                parameter[9] = new SqlParameter("@Neighborhood", model.Neighborhood);
                parameter[10] = new SqlParameter("@Street", model.Street);
                parameter[11] = new SqlParameter("@BuildingNumber", model.BuildingNumber);
                parameter[12] = new SqlParameter("@Id", model.Id);
                string sqlQuery = @"UPDATE Customer
                                       SET ModelState = @ModelState
                                          ,InsertDate = @InsertDate
                                          ,UpdateDate = @UpdateDate
                                          ,NameSurname= @NameSurname
                                          ,Age = @Age
                                          ,GSMNumber = @GSMNumber
                                          ,EMail = @EMail
                                          ,City = @City
                                          ,Distirict = @Distirict
                                          ,Neighborhood = @Neighborhood
                                          ,Street = @Street
                                          ,BuildingNumber = @BuildingNumber
                                     WHERE Id=@Id";
                return DBAdoNet.BaseOperations.AdoBase.Execute(sqlQuery, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Customer> GetAllCustomer()
        {
            try
            {
                string sqlQuery = @"Select * From Customer";
                return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<Customer>(sqlQuery, null);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Customer GetSingleCustomer(int id)
        {
            try
            {
                var parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@Id", id);
                string sqlQuery = @"Select * From Customer where Id=@Id";
                return DBAdoNet.BaseOperations.AdoBase.ExecuteReader<Customer>(sqlQuery, parameter).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
