using CRMSENTITY.Request;
using CRMSENTİTY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMSENTITY.Response;

namespace CRMSDL.Abstract
{
    public interface IProductDL
    {
        public Task<List<PRODUCT>> GetProduct();
        public Task<List<PRODUCT>> FılterProduct(string Fılter, int CatId);
        public Task<List<PRODUCT>> GetProductByCategory(int CatId);
        public Task<PRODUCT> GetProductDetailsById(int Id);
    }
}
