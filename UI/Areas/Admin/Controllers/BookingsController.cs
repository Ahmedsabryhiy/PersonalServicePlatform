using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.Helpers;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IProviderService _providerService;
        private readonly ICustomerService _customerService;
        private readonly IServicesService _serviceService;
        public BookingsController(IBookingService bookingService, ICustomerService customerService, IServicesService servicesService, IProviderService providerService)
        {
            _bookingService = bookingService;
            _providerService = providerService;
           _customerService = customerService;
            _serviceService = servicesService;
        }
        public IActionResult Index() 
        {
            var listBookings = _bookingService.GetAll();
            return View( listBookings);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag . listProviders = new SelectList(_providerService.GetAll(), "Id", "FullName");
            ViewBag .listCustomers = new SelectList(_customerService.GetAll(), "Id", "FullName");
            ViewBag .listServices = new SelectList(_serviceService.GetAll(), "Id", "Name");
            var booking = new TbBookingDTO();
            if (id != null)
            {
                booking = _bookingService.GetById(Convert.ToInt32(id));
            }
            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public IActionResult Save(TbBookingDTO booking)
        {
            if (!ModelState.IsValid)
                return View("Edit", booking);

            try
            {
                if (booking.Id == 0)
                    _bookingService.Add(booking);
                else
                    _bookingService.Update(booking);

                TempData["MessageType"] = MessageTypes.SaveSuccess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.SaveFailed; // Singular key
            }
            return RedirectToAction("Index");
        }

        // Delete Action
     
        public IActionResult Delete(int id)
        {
            try 
            {
                _bookingService.Delete(id);
                TempData["MessageType"] = MessageTypes.DeleteSuccess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.DeleteFailed; // Singular key
            }
            return RedirectToAction("Index");
        }
    }
}
