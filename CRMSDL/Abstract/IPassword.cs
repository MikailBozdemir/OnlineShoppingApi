using CRMSENTITY.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSDL.Abstract
{
    public interface IPassword
    {
        public Task<bool> ChancePasswordAsync(PasswordRequest passwordRequest);
    }
}
