using Application.Contracts;
using Application.Dots;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using UI.Models;


namespace UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IProviderAvailabilityService _providerAvailabilityService;

        public BookingController(IBookingService bookingService, IProviderAvailabilityService providerAvailabilityService)
        {
            _bookingService = bookingService;
            _providerAvailabilityService = providerAvailabilityService;
        }

        // GET: Booking/Book/{serviceId}
        public  IActionResult Index(int serviceId)
        {
            // Retrieve service details (for display purposes)
            var service =  _bookingService.GetById(serviceId);
            if (service == null)
            {
                return NotFound();
            }

            // Retrieve available slots for the service from TbProviderAvailability.
            // Here we assume a simple query to get slots that are not booked.
            var availableSlots = _providerAvailabilityService.GetAll()
                .Where(av => av.ServiceId == serviceId && av.IsBooked == false)
                .Select(av => new
                {
                    Date = av.AvailableDate,
                    StartTime = av.StartTime,
                    EndTime = av.EndTime
                })
                .ToList();

            //// Pass the service and available slots to the view via a ViewModel.
            //var viewModel = new BookingViewModel
            //{
            //    Service = service,
            //    AvailableSlots = availableSlots.Select(s => new AvailableSlot
            //    {
            //        Date = s.Date,
            //        StartTime = s.StartTime,
            //        EndTime = s.EndTime
            //    }).ToList()
            //};

            return View(availableSlots);
        }

        // POST: Booking/Book
        [HttpPost]
        [ValidateAntiForgeryToken]

        public  IActionResult Edit( TbBookingDTO bookingDTO)
        {
            if (!ModelState.IsValid)
            {
                // Return the view with error messages
                return View("Index", bookingDTO);
            }

            // Create a new booking record based on the input.
            var booking = new TbBookingDTO
            {
                ServiceId = bookingDTO .ServiceId,
                CustomerId = bookingDTO.CustomerId,
                ProviderId = bookingDTO.ProviderId,
                BookingDate = DateTime.Now,
                ScheduledStart = bookingDTO.ScheduledStart,
                ScheduledEnd = bookingDTO.ScheduledEnd,
                Status = "Pending",
                TotalPrice = bookingDTO.TotalPrice,
             
            };

            _bookingService.Add(booking);
       

            // Optionally update the availability slot to mark it as booked.
            var slot =  _providerAvailabilityService.GetById(bookingDTO.ProviderId);

            if (slot != null)
            {
                slot.IsBooked = true;
               _providerAvailabilityService.Update(slot);
               
            }

            return RedirectToAction("Confirmation", new { id = booking.Id });
        }
         
        // GET: Booking/Confirmation/{id}
        public IActionResult Confirmation(int id)
        {
            var booking = _bookingService.GetById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }
    }
}

