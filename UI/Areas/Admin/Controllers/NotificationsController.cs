using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
     
    public class NotificationsController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly ICustomerService _customerService;
        public NotificationsController(INotificationService notificationService, ICustomerService customerService)
        {
            _notificationService = notificationService;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var listNotifications = _notificationService.GetAll();
            return View(listNotifications );
        }
        public  IActionResult Edit(int id)
        {
            var listCustomers = new SelectList(_customerService.GetAll(), "Id", "FirstName");
          ViewBag.listCustomers = listCustomers;
            var  notification = new TbNotificattionDTO();
            if (id != 0)
            {
                notification = _notificationService.GetById(id);
            }
            return View(notification);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbNotificattionDTO notification)
        {
            if (!ModelState.IsValid)
                return View("Edit", notification);
            if (notification.Id == 0)
            {
               // notification.CustomerId = 1; 
                _notificationService.Add(notification);
            }
            else
            {
                _notificationService.Update(notification);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _notificationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
