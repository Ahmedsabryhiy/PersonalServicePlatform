using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PersonalServicePlatform.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentMethodsController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IBookingService _bookingService;
        public PaymentMethodsController(IPaymentService paymentService , IBookingService bookingService)
        {
            _paymentService = paymentService;
            _bookingService = bookingService;
        }
        public IActionResult Index()
        {
            var listPayments = _paymentService.GetAll();
            return View( listPayments);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.listBookings =  new SelectList(_bookingService.GetAll(), "Id", "Status");
            var payment = new TbPaymentDTO();
            if (id != null)
            {
                payment = _paymentService.GetById(Convert.ToInt32(id));
            }
            return View(payment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbPaymentDTO payment)
        {
            if (!ModelState.IsValid)
                return View("Edit", payment);
            if (payment.Id == 0)
            {
                _paymentService.Add(payment);
            }
            else
            {
                _paymentService.Update(payment);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _paymentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
