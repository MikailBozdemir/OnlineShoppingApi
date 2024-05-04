using CRMSDL.Abstract;
using CRMSDL.Repository;
using CRMSENTITY.Request;
using CRMSENTITY.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoice _invoiceDL;


        public InvoiceController(IInvoice invoiceDL)
        {
            _invoiceDL = invoiceDL;

        }
        // GET: CategoryController
        [HttpGet]
        [Route("GetInvoiceById/{Id}")]
        public async Task<List<Invoice>> GetInvoiceById(int Id)
        {
            return await _invoiceDL.GetInvoiceById(Id);
        }


        [HttpPost]
        [Route("GetInvoice")]
        public async Task<bool> GetInvoice([FromBody] int Id)
        {
            return await _invoiceDL.GetInvoiced(Id);
        }
        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
