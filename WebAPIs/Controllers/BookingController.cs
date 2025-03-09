using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        // GET: api/<BookingController>
        [HttpGet]

        public ApiResponse GetAll()
        {

            ApiResponse oResponse = new ApiResponse();
            try
            {
                var listBookings = _bookingService.GetAll();
                oResponse.Data = listBookings;
                oResponse.Errors = "null";
                oResponse.StatusCode = 200;
                return oResponse;
            }
            catch (Exception ex)
            {
                oResponse.Data = "null";
                oResponse.Errors = ex.Message;
                oResponse.StatusCode = 500;
                return oResponse;
            }
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                var Booking = _bookingService.GetById(id);
                oResponse.Data = Booking;
                oResponse.Errors = "null";
                oResponse.StatusCode = 200;
                return oResponse;
            }
            catch (Exception ex)
            {
                oResponse.Data = "null";
                oResponse.Errors = ex.Message;
                oResponse.StatusCode = 500;
                return oResponse;
            }
        }

        // POST api/<BookingController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbBookingDTO BookingDto)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _bookingService.Add(BookingDto);
                oResponse.Data = "Added Booking successfully";
                oResponse.Errors = "null";
                oResponse.StatusCode = 200;
                return oResponse;
            }
            catch (Exception ex)
            {
                oResponse.Data = " null";
                oResponse.Errors = ex.Message;
                oResponse.StatusCode = 500;
                return oResponse;
            }
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] TbBookingDTO  BookingDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                if (id != BookingDTO.Id)
                {
                    oResponse.Data = null;
                    oResponse.Errors = "Mismatched Booking ID.";
                    oResponse.StatusCode = 400; // Bad Request
                    return oResponse;
                }
                else
                {
                    _bookingService.Update(BookingDTO);
                    oResponse.Data = "Booking updated successfully";
                    oResponse.Errors = null;
                    oResponse.StatusCode = 200;
                    return oResponse;
                }

            }
            catch (Exception ex)
            {
                oResponse.Data = "null";
                oResponse.Errors = ex.Message;
                oResponse.StatusCode = 500;
                return oResponse;
            }
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _bookingService.Delete(id);
                oResponse.Data = " Booking deleted successfully";
                oResponse.Errors = null;
                oResponse.StatusCode = 200;
                return oResponse;
            }
            catch (Exception ex)
            {
                oResponse.Data = null;
                oResponse.Errors = ex.Message;
                oResponse.StatusCode = 500;
                return oResponse;
            }
        }
    }
}
