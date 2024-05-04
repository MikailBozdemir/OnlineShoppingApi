using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSENTITY.Response
{
    public class CartResponse
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public DateTime AdditionDay { get; set; }
        public  double TotalPrice { get; set; }
    }
}
