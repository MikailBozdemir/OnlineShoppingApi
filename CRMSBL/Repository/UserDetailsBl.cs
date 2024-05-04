using CRMSBL;
using CRMSENTİTY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMSDL;
using CRMSDL.Abstract;
using System.Data;

namespace CRMS2BL.Repsoitory
{
    public class UserDetailsBl : IUserDetails
    {

        public IUserDetailsDL UserDetailDL { get; set; }
        private readonly IUserDetailsDL _userDetailsDL;

        public UserDetailsBl(IUserDetailsDL userDetailsDL)
        {
            _userDetailsDL = userDetailsDL;
        }


        public  async Task<List<userResponse>> GetUserDetailById(int Id)
        {
           return await  _userDetailsDL.GetUserDetailsByIdAsync(1);
            
        }

        Task<userResponse> IUserDetails.GetUserDetailById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
