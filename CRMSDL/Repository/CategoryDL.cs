using CRMSDL.Abstract;
using CRMSENTITY.Response;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSDL.Repository
{
    public class CategoryDL : ICategory
    {
        public async Task<List<Category>> GetCategory()
        {

            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;

            List<Category> categories = new List<Category>();


            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "getAllCategory";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("tt", OracleDbType.RefCursor
                           , 256)).Direction = ParameterDirection.ReturnValue;

                        cmd.ExecuteNonQuery();


                        OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["tt"].Value).GetDataReader();
                        while (reader.Read())
                        {
                            Category _category = new Category();
                            _category.CategoryID = await reader.IsDBNullAsync(0) ? 0 : Convert.ToInt32(reader.GetString(0));
                            _category.CategoryName = await reader.IsDBNullAsync(1) ? "Bulunamdı" : reader.GetString(1);
                            _category.STATUS = await reader.IsDBNullAsync(2) ? "Bulunamdı" : reader.GetString(2);
                           
                            categories.Add(_category);


                        }
                        await reader.DisposeAsync();
                        return categories;
                    }
                }

            }
            catch (OracleException ex)
            {

                throw ex;

            }
            finally
            {
                if (oracleConnection != null)
                {
                    oracleConnection.Close();
                }
            }
        }
    }
}
