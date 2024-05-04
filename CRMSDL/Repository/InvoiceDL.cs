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
    public class InvoiceDL:IInvoice
    {
        #region GetInvoiceDetailsByUserId
        public async Task<List<Invoice>> GetInvoiceById(int Id)
        {

            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;

            List<Invoice> invoice = new List<Invoice>();


            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "P_Invoice.getAllInvoiceById";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("tt", OracleDbType.RefCursor
                           , 256)).Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(new OracleParameter("uid", OracleDbType.Int64, Id, ParameterDirection.Input
                           ));


                        cmd.ExecuteNonQuery();


                        OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["tt"].Value).GetDataReader();
                        while (reader.Read())
                        {
                            Invoice _invoice = new Invoice();
                            _invoice.InvoiceId = await reader.IsDBNullAsync(0) ? 0 : Convert.ToInt32(reader.GetString(0));
                            _invoice.UserId = await reader.IsDBNullAsync(1) ? 0 : Convert.ToInt32(reader.GetString(1));
                            _invoice.ProductId = await reader.IsDBNullAsync(2) ? 0 : Convert.ToInt32(reader.GetString(2));
                            _invoice.InvoiceDate = await reader.IsDBNullAsync(3) ? DateTime.MinValue : Convert.ToDateTime(reader.GetString(3));
                            _invoice.TotalPrice = await reader.IsDBNullAsync(4) ? 0 : Convert.ToDouble(reader.GetString(4));
                            _invoice.Adress = await reader.IsDBNullAsync(5) ? "Bulunamdı" : reader.GetString(5);
                            _invoice.UserName = await reader.IsDBNullAsync(6) ? "Bulunamdı" : reader.GetString(6);
                            _invoice.Amount = await reader.IsDBNullAsync(7) ? 0 : Convert.ToInt32(reader.GetString(7));
                            _invoice.ProductName = await reader.IsDBNullAsync(8) ? "Bulunamdı" : reader.GetString(8);
                            _invoice.TotalPriceByProduct = await reader.IsDBNullAsync(9) ? 0 : Convert.ToDouble(reader.GetString(9));


                            invoice.Add(_invoice);


                        }
                        await reader.DisposeAsync();
                        return invoice;
                    }
                }

            }
            catch (OracleException ex)
            {

                invoice = null;
                return invoice;

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

        #region GetInvoiced

       
        public async Task<bool> GetInvoiced(int Id)
        {

            string connectionString = "User Id=SYS;Password=123;Data Source=DESKTOP-7ucpu53/TEST.mikailbozdemir:SYSTEM; DBA Privilege=SYSDBA";
            OracleConnection oracleConnection = null;

            List<Invoice> invoice = new List<Invoice>();


            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "P_Invoice.getInvoiced";
                        cmd.CommandType = CommandType.StoredProcedure;
                    
                        cmd.Parameters.Add(new OracleParameter("uid", OracleDbType.Int64, Id, ParameterDirection.Input
                           ));


                        cmd.ExecuteNonQuery();


                      
                        return true;
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
