using CRMSENTİTY;
using CRMSENTITY;
using CRMSENTITY.Request;
using CRMSENTITY.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSDL.Abstract
{
    public interface IUserDetailsDL
    {

        // get Methodu
        public Task<userResponse> GetUserLoginAsync(UserRequest userRequest);
       
        
    }
}
