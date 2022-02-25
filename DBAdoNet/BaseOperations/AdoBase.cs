using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DBAdoNet.BaseOperations
{
    public class AdoBase
    {

        // connection
        // Execute
        // ExecuteReader
        // SqlDataAdapter 

        // DataSet [ 1 den fazla DataTable Barındırır]
        // DataTable { Table }
        // ds[0]
        // Array 0,1,2,3
      

        private static string ConnectAdress()
        {
            string appConnect = null;

            if (ConfigurationManager.ConnectionStrings["DbConnect"] != null)
            {
                appConnect= ConfigurationManager.ConnectionStrings["DbConnect"].ToString();
            }

            else if (ConfigurationManager.AppSettings["DbConnect"] != null)
            {
                appConnect= ConfigurationManager.AppSettings["DbConnect"].ToString();
            }
            return appConnect;
            //return @"Server=localhost\SQLEXPRESS;Database=Ronwell;Trusted_Connection=True;";
        }




        public static int Execute(string sqlQuery, SqlParameter[] parameters)
        {
            try
            {
                int state = 0;
                using (SqlConnection connect = new SqlConnection(ConnectAdress()))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connect))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        connect.Open();
                        state = command.ExecuteNonQuery();
                    }
                }
                return state;
            }
            catch (Exception)
            {
                throw;
            }

        }


       

        private static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }

        public static List<T>  ExecuteReader<T>(string sqlQuery, SqlParameter[] parameters)
        {
            List<T> objList = new List<T>();
            try
            {
                using (SqlConnection connect = new SqlConnection(ConnectAdress()))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connect))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        connect.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                DataTable dt = new DataTable();
                                dt.Load(reader);
                                objList = ConvertToList<T>(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objList;
        }

        public static DataTable ExecuteDataAdapter(string sqlQuery, SqlParameter[] parameters)
        {
            try
            {
                DataSet ds = new DataSet(); // birden fazla datatable alır
                DataTable dataTable = new DataTable();
                using (SqlConnection connect = new SqlConnection(ConnectAdress()))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connect))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                return dataTable;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private static DataTable GetDataTable<T>( IList<T> data)
        {
            DataTable table = new DataTable();
            try
            {
                PropertyDescriptorCollection properties =
                       TypeDescriptor.GetProperties(typeof(T));

                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
            }
            catch
            {
                throw;
            }
            return table;
        }



        public static void BulkInsert<T>(List<T> list,string tableName)
        {
            try
            {
                using (DataTable dt = GetDataTable(list))
                {
                    using (SqlConnection connect = new SqlConnection(ConnectAdress()))
                    {
                        using (SqlBulkCopy bulk = new SqlBulkCopy(connect))
                        {
                            
                            connect.Open();
                            bulk.BulkCopyTimeout = 60;
                            bulk.BatchSize = 1000;
                            bulk.DestinationTableName = tableName;
                            bulk.WriteToServer(dt);
                        }
                    }
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
