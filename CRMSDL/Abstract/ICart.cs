using CRMSENTITY.Request;
using CRMSENTITY.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSDL.Abstract
{
    public  interface ICart
    {
        public Task<List<CartResponse>> GetCartById(int Id);
        public  Task<bool> AddToCart (CartRequset cartRequset);
        public  Task<bool> RemoveFromCart (CartRequset cartRequset);
    }
}
