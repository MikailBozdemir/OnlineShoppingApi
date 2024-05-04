using CRMSDL.Abstract;
using CRMSENTITY.Request;
using CRMSENTITY.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cartDL;


        public CartController(ICart cartDL)
        {
            _cartDL = cartDL;

        }
        // GET: CategoryController
        [HttpGet]
        [Route("GetCartById/{Id}")]
        public async Task<List<CartResponse>> GetCartById(int Id)
        {
            return await _cartDL.GetCartById(Id);
        }

        // GET api/<CartController>/5
       

        // POST api/<CartController>
        [HttpPost]
        [Route("AddToCart")]
        public  async Task<bool> AddToCart( [FromBody]CartRequset cartRequset)
        {
            return await _cartDL.AddToCart(cartRequset);
        }

        [HttpPost]
        [Route("RemoveFromCart")]
        public async Task<bool> RemoveFromCart([FromBody] CartRequset cartRequset)
        {
            return await _cartDL.RemoveFromCart(cartRequset);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
