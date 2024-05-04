using CRMSDL.Abstract;
using CRMSENTITY.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

      
        private readonly IProductDL _productDL;
        

        public ProductController(IProductDL productDL)
        {
            _productDL = productDL;
            
        }




        // GET: api/<Product>
        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<List<PRODUCT>> GetAllProduct()
        {
            return  await _productDL.GetProduct();
        }




        [HttpGet]
        [Route("FilterProduct/{Fılter}/{CatId}")]
        public async Task<List<PRODUCT>> FılterProduct(string Fılter,int CatId)
        {
            return await _productDL.FılterProduct( Fılter,  CatId);
        }



        [HttpGet]
        [Route("GetAllProduct/{CatId}")]
        public async Task<List<PRODUCT>> GetProductByCategory( int CatId)
        {
            return await _productDL.GetProductByCategory( CatId);
        }

        // GET api/<Product>/5
        [HttpGet]
        [Route("GetProductById/{Id}")]
        public async Task<PRODUCT> GetProductById(int Id)
        {
            return  await  _productDL.GetProductDetailsById(Id);
        }

        // POST api/<Product>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Product>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Product>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
