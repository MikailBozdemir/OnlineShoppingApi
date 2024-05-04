using CRMSDL.Abstract;
using CRMSENTITY.Request;
using CRMSENTITY.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Controllers
{
    public class PasswordController : Controller
    {
        private readonly IPassword _passwordDl;


        public PasswordController(IPassword passwordDl)
        {
            _passwordDl = passwordDl;

        }
        // GET: CategoryController
        [HttpPost]
        [Route("ChancePassword")]
        public async Task<bool> GetCartById([FromBody]PasswordRequest passwordRequest)
        {
            return await _passwordDl.ChancePasswordAsync(passwordRequest);
        }
    }
}
