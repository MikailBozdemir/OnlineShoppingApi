using CRMSDL.Abstract;
using CRMSENTİTY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

using System.Data.Common;
using System.Data;
using Oracle.ManagedDataAccess.Types;
using CRMSENTITY.Response;
using CRMSENTITY;
using CRMSENTITY.Request;
using System.Reflection.PortableExecutable;

namespace CRMSDL.Repository
{
    public class UserDetailsDL : IUserDetailsDL
    {
        #region UserLogin
        public async Task<userResponse> GetUserLoginAsync( UserRequest userRequest )
        {
            userResponse result = new userResponse();
           

            result = await GetUserLogin(userRequest);
            return result;
        }

        //Task<List<userResponse>>
        public async Task<userResponse> GetUserLogin(UserRequest userRequest)
        {
            bool isUserValid = false;
            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;
            userResponse _user = new userResponse();
            
            List<userResponse> userDetail = new List<userResponse>();


            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "P_Users.isUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("tt", OracleDbType.RefCursor
                           , 256)).Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(new OracleParameter("usrName", OracleDbType.NVarchar2,256, userRequest.USERNAME, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("userPassword", OracleDbType.NVarchar2,256, userRequest.PASSWORD, ParameterDirection.InputOutput));
                        cmd.ExecuteNonQuery();

                       
                       OracleDataReader reader= ((OracleRefCursor)cmd.Parameters["tt"].Value).GetDataReader();
                       while (reader.Read())
                        {
                            
                            _user.USERID = await reader.IsDBNullAsync(0) ? 0 : Convert.ToInt32(reader.GetString(0));
                            _user.USERNAME = await reader.IsDBNullAsync(1) ? "Bulunamdı" : reader.GetString(1);
                            _user.PASSWORD = await reader.IsDBNullAsync(2) ? "Bulunamdı" : reader.GetString(2);
                            

                        }
                        await reader.DisposeAsync();
                        return _user;
                    }
                }

            }
            catch (OracleException ex)
            {
                _user.USERID =-1;
                _user.USERNAME = null;
                _user.PASSWORD = null;
                return _user;

            }
            finally
            {
                if (oracleConnection != null)
                {
                    oracleConnection.Close();
                }
            }

        }
        #endregion
    }
}
