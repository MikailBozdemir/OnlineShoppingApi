using CRMSDL.Abstract;
using CRMSENTITY.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        private readonly ICategory _categoryDL;


        public CategoryController(ICategory categoryDL)
        {
            _categoryDL = categoryDL;

        }
        // GET: CategoryController
        [HttpGet]
        public async Task<List<Category>> Index()
        {
            return  await _categoryDL.GetCategory();
        }

       
      
        // POST: CategoryController/Create
        

      
    }
}
