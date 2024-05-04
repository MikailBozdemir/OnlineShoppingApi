using CRMSDL.Abstract;
using CRMSENTITY.Request;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSDL.Repository
{
    public class PasswordDl:IPassword
    {
        public async Task<bool> ChancePasswordAsync(PasswordRequest passwordRequest)
        {

            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;




            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "p_Users.changePassword";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("passwordRequest", OracleDbType.NVarchar2,256,passwordRequest.UserName, ParameterDirection.Input
                           ));
                        cmd.Parameters.Add(new OracleParameter("pswrd", OracleDbType.NVarchar2,256,passwordRequest.Password, ParameterDirection.InputOutput
                           ));
                        cmd.Parameters.Add(new OracleParameter("newPassword", OracleDbType.NVarchar2,256, passwordRequest.NewPassword, ParameterDirection.InputOutput
                          ));
                        cmd.ExecuteNonQuery();

                        return true; ;
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
