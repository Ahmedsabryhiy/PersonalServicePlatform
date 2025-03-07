using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController( ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
         
        public ApiResponse GetAll()
        {

            ApiResponse oResponse = new ApiResponse();
            try
            {
                var listCustomers = _customerService.GetAll();
                oResponse.Data =  listCustomers ;
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

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            ApiResponse oResponse= new ApiResponse();
            try
            {
              var customer= _customerService.GetById(id);
                oResponse.Data = customer;
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

        // POST api/<CustomerController>
        [HttpPost]
        public ApiResponse  Post([FromBody]  TbCustomerProfileDTO CustomerProfileDto)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _customerService.Add(CustomerProfileDto);
                oResponse.Data = "Added customer successfully";
                oResponse .Errors = "null";
                oResponse .StatusCode = 200;
                return oResponse;
            }
            catch(Exception ex)
            {
                oResponse.Data = " null";
                oResponse.Errors = ex.Message;
                oResponse.StatusCode = 500;
                return oResponse;
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] TbCustomerProfileDTO customerProfileDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                if (id != customerProfileDTO.Id)
                {
                    oResponse.Data = null;
                    oResponse.Errors = "Mismatched customer ID.";
                    oResponse.StatusCode = 400; // Bad Request
                    return oResponse;
                }
                else
                {
                    _customerService.Update(customerProfileDTO);
                    oResponse.Data = "customer updated successfully";
                    oResponse.Errors = null;
                    oResponse.StatusCode = 200;
                    return oResponse;
                }

            }
            catch (Exception ex)
            {
                oResponse.Data = "null";
                oResponse.Errors =ex.Message;
                oResponse.StatusCode=500;
                return oResponse;
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _customerService.Delete(id);
                oResponse.Data = " customer deleted successfully";
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
