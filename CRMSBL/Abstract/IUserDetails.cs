using CRMSENTİTY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSBL
{
    public interface IUserDetails
    {
        public  Task<userResponse> GetUserDetailById(int Id);
    }
}
