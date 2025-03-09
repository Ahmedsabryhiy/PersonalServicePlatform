using Application.Contracts;
using Application.Dots;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
         private readonly    IProviderService  _providerService;
        public ProviderController( IProviderService providerService )
        {
             _providerService = providerService;
        }
        // GET: api/<ProviderController>
        [HttpGet]
        public ApiResponse GetAll()
        {
            ApiResponse oResponse= new ApiResponse();
            try
            {
                var listProviders= _providerService.GetAll();

                oResponse.Data = listProviders; 
                oResponse.Errors = "null";
                oResponse.StatusCode = 200;
                return oResponse;
            }
            catch( Exception ex ) 
            {
                oResponse.Data = "null";
                oResponse .Errors = ex.Message;
                oResponse.StatusCode=500;
                return oResponse;
            }
            
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public ApiResponse  GetById(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                var provider= _providerService.GetById(id);
                oResponse.Data =  provider ;
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

        [HttpPost]
        public ApiResponse Post([FromBody] TbProviderProfileDTO providerProfileDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _providerService.Add(providerProfileDTO );
                oResponse.Data = "Added provider successfully";
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


        // PUT api/<providerController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody]  TbProviderProfileDTO  providerProfileDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                if (id != providerProfileDTO.Id)
                {
                    oResponse.Data = null;
                    oResponse.Errors = "Mismatched provider ID.";
                    oResponse.StatusCode = 400; // Bad Request
                    return oResponse;
                }
                else
                {
                    _providerService.Update(providerProfileDTO);
                    oResponse.Data = "provider updated successfully";
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

        // DELETE api/<providerController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _providerService.Delete(id);
                oResponse.Data = " provider deleted successfully";
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
