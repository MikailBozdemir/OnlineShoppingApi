using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSENTITY.Request
{
    public class CartRequset
    {
        public int ProductId { get; set; }
        public int CutomerId { get; set; }
        public int Amount { get; set; }
    }
}
