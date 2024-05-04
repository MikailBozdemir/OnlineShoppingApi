using CRMSENTITY.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSDL.Abstract
{
    public interface IInvoice
    {
        public Task<List<Invoice>> GetInvoiceById(int Id);
        public Task<bool> GetInvoiced(int Id);
    }
}
