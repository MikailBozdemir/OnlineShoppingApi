using CRMSDL.Abstract;
using CRMSDL.Repository;
using CRMSENTİTY;
using CRMSENTITY;
using CRMSENTITY.Request;
using CRMSENTITY.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        

        public IUserDetailsDL UserDetailDL { get; set; }
        private readonly IUserDetailsDL _userDetailsDL;
        private readonly ILogger<IUserDetailsDL> _logger;

        public UserController(IUserDetailsDL userDetailsDL,ILogger<IUserDetailsDL> logger)
        {
            _userDetailsDL = userDetailsDL;
            _logger = logger;
        } 
        

        //[HttpGet]
        //[Route("GetUserLogin")]
        //public async Task<userResponse> GetUserLogin([FromQuery] UserRequest userRequest)
        //{
        //    return await _userDetailsDL.GetUserLoginAsync(userRequest);
        //}

        [HttpPost]
        [Route("GetUserLogin")]
        public async Task<userResponse> GetUserLogin([FromBody] UserRequest userRequest)
        {
            return await _userDetailsDL.GetUserLoginAsync(userRequest);
        }


     


    }
}
