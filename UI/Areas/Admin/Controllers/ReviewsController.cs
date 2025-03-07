using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;
        public ReviewsController(IReviewService reviewService, ICustomerService customerService, IBookingService bookingService)
        {
            _reviewService = reviewService;
            _customerService = customerService;
            _bookingService = bookingService;
        }
        public IActionResult Index()
        {
            var listReviews = _reviewService.GetAll();
            return View(listReviews);
           
        }
        public IActionResult Edit(int? id)
        {
            var listCustomers = _customerService.GetAll();
            var listBookings = _bookingService.GetAll();
            var review = new TbReviewDTO();
            if (id != null)
            {
                review = _reviewService.GetById(Convert.ToInt32(id));
            }
           
            return View(review);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbReviewDTO review)
        {
            if (!ModelState.IsValid)
                return View("Edit", review);
            if (review.Id == 0)
            {
                _reviewService.Add(review);
            }
            else
            {
                _reviewService.Update(review);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _reviewService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
