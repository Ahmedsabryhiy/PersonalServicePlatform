using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderAvailabilityController : ControllerBase
    {
        private readonly IProviderAvailabilityService _providerAvailabilityService;
        public ProviderAvailabilityController(IProviderAvailabilityService providerAvailabilityService)
        {
            _providerAvailabilityService = providerAvailabilityService;
        }
        // GET: api/<providerAvailabilityController>
        [HttpGet]

        public ApiResponse GetAll()
        {

            ApiResponse oResponse = new ApiResponse();
            try
            {
                var listproviderAvailabilitys = _providerAvailabilityService.GetAll();
                oResponse.Data = listproviderAvailabilitys;
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

        // GET api/<providerAvailabilityController>/5
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                var providerAvailability = _providerAvailabilityService.GetById(id);
                oResponse.Data = providerAvailability;
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

        // POST api/<providerAvailabilityController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbProviderAvailabilityDTO providerAvailabilityDto)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _providerAvailabilityService.Add(providerAvailabilityDto);
                oResponse.Data = "Added providerAvailability successfully";
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

        // PUT api/<providerAvailabilityController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] TbProviderAvailabilityDTO  providerAvailabilityDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                if (id != providerAvailabilityDTO.Id)
                {
                    oResponse.Data = null;
                    oResponse.Errors = "Mismatched providerAvailability ID.";
                    oResponse.StatusCode = 400; // Bad Request
                    return oResponse;
                }
                else
                {
                    _providerAvailabilityService.Update(providerAvailabilityDTO);
                    oResponse.Data = "providerAvailability updated successfully";
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

        // DELETE api/<providerAvailabilityController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _providerAvailabilityService.Delete(id);
                oResponse.Data = " providerAvailability deleted successfully";
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
