using CRMSDL.Abstract;
using CRMSENTITY.Request;
using CRMSENTITY.Response;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.WebUtilities;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRMSDL.Repository
{
    public class CartDL:ICart
    {

        #region GetCartById
        public async Task<List<CartResponse>> GetCartById(int Id)
        {

            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;

            List<CartResponse> cartDetails = new List<CartResponse>();


            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "P_Basket.getBasket";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("tt", OracleDbType.RefCursor
                           , 256)).Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(new OracleParameter("user_id", OracleDbType.Int64, Id, ParameterDirection.Input
                           ));


                        cmd.ExecuteNonQuery();


                        OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["tt"].Value).GetDataReader();
                        while (reader.Read())
                        {
                            CartResponse _cart = new CartResponse();
                            _cart.UserId = await reader.IsDBNullAsync(0) ? 0 : Convert.ToInt32(reader.GetString(0));
                            _cart.ProductId = await reader.IsDBNullAsync(1) ? 0 : Convert.ToInt32(reader.GetString(1));
                            _cart.Amount = await reader.IsDBNullAsync(2) ? 0 : Convert.ToInt32(reader.GetString(2));
                            _cart.Status = await reader.IsDBNullAsync(3) ? "Bulunamdı" : reader.GetString(3);
                            _cart.AdditionDay = await reader.IsDBNullAsync(4) ? DateTime.MinValue : Convert.ToDateTime(reader.GetString(4));
                            _cart.ProductName = await reader.IsDBNullAsync(5) ? "Bulunamdı" : reader.GetString(5);
                            _cart.TotalPrice = await reader.IsDBNullAsync(6) ? 0 : Convert.ToDouble(reader.GetString(6));


                            cartDetails.Add(_cart);


                        }
                        await reader.DisposeAsync();
                        return cartDetails;
                    }
                }

            }
            catch (OracleException ex)
            {

               
                    cartDetails = null;
                    return cartDetails;
                

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



        #region AddToCart
        public async Task<bool> AddToCart(CartRequset cartRequset)
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
                        cmd.CommandText = "P_Basket.addToBasket";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new OracleParameter("uId", OracleDbType.Int64, cartRequset.CutomerId, ParameterDirection.Input
                           ));
                        cmd.Parameters.Add(new OracleParameter("pId", OracleDbType.Int64, cartRequset.ProductId, ParameterDirection.Input
                           ));
                        cmd.Parameters.Add(new OracleParameter("amn", OracleDbType.Int64, cartRequset.Amount, ParameterDirection.Input
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
        #endregion


        #region RemoveFromCart
        public async Task<bool> RemoveFromCart(CartRequset cartRequset)
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
                        cmd.CommandText = "P_Basket.removeFromBasket";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new OracleParameter("uId", OracleDbType.Int64, cartRequset.CutomerId, ParameterDirection.Input
                           ));
                        cmd.Parameters.Add(new OracleParameter("pId", OracleDbType.Int64, cartRequset.ProductId, ParameterDirection.Input
                           ));
                        cmd.Parameters.Add(new OracleParameter("amn", OracleDbType.Int64, cartRequset.Amount, ParameterDirection.Input
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
        #endregion

    }
}
