using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSENTITY.Response
{
    public  class PRODUCT
    {
        public int PRODUCTID { get; set; }
        public string PRODUCTNAME { get; set; }
        public string STATUS { get; set; }
        public double PRICE { get; set; }
        public int CATEGORYID { get; set; }
        public string DESCRIPTION { get; set; }
        public string ImageUrl { get; set; }
    }
}
