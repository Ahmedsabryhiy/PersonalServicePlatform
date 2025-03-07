using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _ServiceService;
        public ServiceController(IServicesService ServiceService)
        {
            _ServiceService = ServiceService;
        }
        // GET: api/<ServiceController>
        [HttpGet]

        public ApiResponse GetAll()
        {

            ApiResponse oResponse = new ApiResponse();
            try
            {
                var listServices = _ServiceService.GetAll();
                oResponse.Data = listServices;
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

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                var Service = _ServiceService.GetById(id);
                oResponse.Data = Service;
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

        // POST api/<ServiceController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbServiceDTO ServiceDto)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _ServiceService.Add(ServiceDto);
                oResponse.Data = "Added Service successfully";
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

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] TbServiceDTO ServiceDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                if (id != ServiceDTO.Id)
                {
                    oResponse.Data = null;
                    oResponse.Errors = "Mismatched Service ID.";
                    oResponse.StatusCode = 400; // Bad Request
                    return oResponse;
                }
                else
                {
                    _ServiceService.Update(ServiceDTO);
                    oResponse.Data = "Service updated successfully";
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

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _ServiceService.Delete(id);
                oResponse.Data = " Service deleted successfully";
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
