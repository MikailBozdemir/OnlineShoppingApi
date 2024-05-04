using CRMSDL.Abstract;
using CRMSENTITY.Request;
using CRMSENTİTY;
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
    public class ProductsDetails : IProductDL
    {


        #region getProduct
        public async Task<List<PRODUCT>> GetProduct()
        {

            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;


            List<PRODUCT> productDetail = new List<PRODUCT>();


            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "P_Product.GetAllProduct";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("tt", OracleDbType.RefCursor
                           , 256)).Direction = ParameterDirection.ReturnValue;

                        cmd.ExecuteNonQuery();


                        OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["tt"].Value).GetDataReader();
                        while (reader.Read())
                        {
                            PRODUCT _product = new PRODUCT();
                            _product.PRODUCTID = await reader.IsDBNullAsync(0) ? 0 : Convert.ToInt32(reader.GetString(0));
                            _product.PRODUCTNAME = await reader.IsDBNullAsync(1) ? "Bulunamdı" : reader.GetString(1);
                            _product.STATUS = await reader.IsDBNullAsync(2) ? "Bulunamdı" : reader.GetString(2);
                            _product.PRICE = await reader.IsDBNullAsync(3) ? 0 : Convert.ToDouble(reader.GetString(3));
                            _product.CATEGORYID = await reader.IsDBNullAsync(4) ? 0 : Convert.ToInt32(reader.GetString(4));
                            _product.DESCRIPTION = await reader.IsDBNullAsync(5) ? "Bulunamdı" : reader.GetString(5);
                            _product.ImageUrl = await reader.IsDBNullAsync(6) ? "Bulunamdı" : reader.GetString(6);

                            productDetail.Add(_product);


                        }
                        await reader.DisposeAsync();
                        return productDetail;
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

        #region FılterProduct

       
        public async Task<List<PRODUCT>> FılterProduct(string Fılter, int CatId)
        {

            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;


            List<PRODUCT> productDetail = new List<PRODUCT>();


            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "P_Product.filterProduct";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("tt", OracleDbType.RefCursor
                           , 256)).Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(new OracleParameter("type", OracleDbType.NVarchar2, 256, Fılter, ParameterDirection.Input));  
                        cmd.Parameters.Add(new OracleParameter("categoryId", OracleDbType.NVarchar2, 256, CatId, ParameterDirection.Input));

                        cmd.ExecuteNonQuery();


                        OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["tt"].Value).GetDataReader();
                        while (reader.Read())
                        {
                            PRODUCT _product = new PRODUCT();
                            _product.PRODUCTID = await reader.IsDBNullAsync(0) ? 0 : Convert.ToInt32(reader.GetString(0));
                            _product.PRODUCTNAME = await reader.IsDBNullAsync(1) ? "Bulunamdı" : reader.GetString(1);
                            _product.STATUS = await reader.IsDBNullAsync(2) ? "Bulunamdı" : reader.GetString(2);
                            _product.PRICE = await reader.IsDBNullAsync(3) ? 0 : Convert.ToDouble(reader.GetString(3));
                            _product.CATEGORYID = await reader.IsDBNullAsync(4) ? 0 : Convert.ToInt32(reader.GetString(4));
                            _product.DESCRIPTION = await reader.IsDBNullAsync(5) ? "Bulunamdı" : reader.GetString(5);
                            _product.ImageUrl = await reader.IsDBNullAsync(6) ? "Bulunamdı" : reader.GetString(6);

                            productDetail.Add(_product);


                        }
                        await reader.DisposeAsync();
                        return productDetail;
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

        #region GetProductByCategory

       
        public async Task<List<PRODUCT>> GetProductByCategory( int CatId)
        {

            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;


            List<PRODUCT> productDetail = new List<PRODUCT>();


            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "P_Product.getProductByCategory";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("tt", OracleDbType.RefCursor
                           , 256)).Direction = ParameterDirection.ReturnValue;
                      
                        cmd.Parameters.Add(new OracleParameter("catId", OracleDbType.NVarchar2, 256, CatId, ParameterDirection.Input));

                        cmd.ExecuteNonQuery();


                        OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["tt"].Value).GetDataReader();
                        while (reader.Read())
                        {
                            PRODUCT _product = new PRODUCT();
                            _product.PRODUCTID = await reader.IsDBNullAsync(0) ? 0 : Convert.ToInt32(reader.GetString(0));
                            _product.PRODUCTNAME = await reader.IsDBNullAsync(1) ? "Bulunamdı" : reader.GetString(1);
                            _product.STATUS = await reader.IsDBNullAsync(2) ? "Bulunamdı" : reader.GetString(2);
                            _product.PRICE = await reader.IsDBNullAsync(3) ? 0 : Convert.ToDouble(reader.GetString(3));
                            _product.CATEGORYID = await reader.IsDBNullAsync(4) ? 0 : Convert.ToInt32(reader.GetString(4));
                            _product.DESCRIPTION = await reader.IsDBNullAsync(5) ? "Bulunamdı" : reader.GetString(5);
                            _product.ImageUrl = await reader.IsDBNullAsync(6) ? "Bulunamdı" : reader.GetString(6);

                            productDetail.Add(_product);


                        }
                        await reader.DisposeAsync();
                        return productDetail;
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

        #region GetProductDetailsByProductId


        public async Task<PRODUCT> GetProductDetailsById(int Id)
        {

            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;


            PRODUCT _product = new PRODUCT();


            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "P_Product.GetProductDetails";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("tt", OracleDbType.RefCursor
                           , 256)).Direction = ParameterDirection.ReturnValue;

                        cmd.Parameters.Add(new OracleParameter("Id", OracleDbType.Int32, Id, ParameterDirection.Input));

                        cmd.ExecuteNonQuery();


                        OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["tt"].Value).GetDataReader();
                        while (reader.Read())
                        {
                            
                            _product.PRODUCTID = await reader.IsDBNullAsync(0) ? 0 : Convert.ToInt32(reader.GetString(0));
                            _product.PRODUCTNAME = await reader.IsDBNullAsync(1) ? "Bulunamdı" : reader.GetString(1);
                            _product.STATUS = await reader.IsDBNullAsync(2) ? "Bulunamdı" : reader.GetString(2);
                            _product.PRICE = await reader.IsDBNullAsync(3) ? 0 : Convert.ToDouble(reader.GetString(3));
                            _product.CATEGORYID = await reader.IsDBNullAsync(4) ? 0 : Convert.ToInt32(reader.GetString(4));
                            _product.DESCRIPTION = await reader.IsDBNullAsync(5) ? "Bulunamdı" : reader.GetString(5);
                            _product.ImageUrl = await reader.IsDBNullAsync(6) ? "Bulunamdı" : reader.GetString(6);




                        }
                        await reader.DisposeAsync();
                        return _product;
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
