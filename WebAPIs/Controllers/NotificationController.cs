using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        // GET: api/<NotificationController>
        [HttpGet]

        public ApiResponse GetAll()
        {

            ApiResponse oResponse = new ApiResponse();
            try
            {
                var listNotifications = _notificationService.GetAll();
                oResponse.Data = listNotifications;
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

        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                var Notification = _notificationService.GetById(id);
                oResponse.Data = Notification;
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

        // POST api/<NotificationController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbNotificattionDTO notificationDto)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _notificationService.Add(notificationDto);
                oResponse.Data = "Added Notification successfully";
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

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] TbNotificattionDTO notificationDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                if (id != notificationDTO .Id)
                {
                    oResponse.Data = null;
                    oResponse.Errors = "Mismatched Notification ID.";
                    oResponse.StatusCode = 400; // Bad Request
                    return oResponse;
                }
                else
                {
                    _notificationService.Update( notificationDTO);
                    oResponse.Data = "Notification updated successfully";
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

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _notificationService.Delete(id);
                oResponse.Data = " Notification deleted successfully";
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
