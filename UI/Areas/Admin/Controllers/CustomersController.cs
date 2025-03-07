using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using UI.Helpers;

namespace   UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var listCustomers = _customerService.GetAll();
            return View( listCustomers );
        }
        public IActionResult Edit(int? id)
        {
            var customer = new TbCustomerProfileDTO();
            if (id != null)
            {
                customer = _customerService.GetById(Convert.ToInt32(id));
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbCustomerProfileDTO customer)
        {

            if (!ModelState.IsValid)
                return View("Edit", customer);
            try
            {
                if (customer.Id == 0)
                {
                    _customerService.Add(customer);
                }
                else
                {
                    _customerService.Update(customer);
                }
                TempData["MessageType"] = MessageTypes.SaveSuccess;
               
            }
            catch (Exception ex)
            {
               TempData["MessageType"] = MessageTypes.SaveFailed;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            try
            {
                 _customerService.Delete(id);
                TempData["MessageType"] = MessageTypes.DeleteSuccess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.DeleteFailed;
            }
            return RedirectToAction("Index");
        }
    }
}
