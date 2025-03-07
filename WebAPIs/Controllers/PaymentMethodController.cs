using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentService _paymentMethodService;
        public PaymentMethodController(IPaymentService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }
        // GET: api/<PaymentMethodController>
        [HttpGet]

        public ApiResponse GetAll()
        {

            ApiResponse oResponse = new ApiResponse();
            try
            {
                var listPaymentMethods = _paymentMethodService.GetAll();
                oResponse.Data = listPaymentMethods;
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

        // GET api/<PaymentMethodController>/5
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                var PaymentMethod = _paymentMethodService.GetById(id);
                oResponse.Data = PaymentMethod;
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

        // POST api/<PaymentMethodController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbPaymentDTO PaymentMethodDto)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _paymentMethodService.Add(PaymentMethodDto);
                oResponse.Data = "Added PaymentMethod successfully";
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

        // PUT api/<PaymentMethodController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] TbPaymentDTO PaymentMethodDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                if (id != PaymentMethodDTO.Id)
                {
                    oResponse.Data = null;
                    oResponse.Errors = "Mismatched PaymentMethod ID.";
                    oResponse.StatusCode = 400; // Bad Request
                    return oResponse;
                }
                else
                {
                    _paymentMethodService.Update(PaymentMethodDTO);
                    oResponse.Data = "PaymentMethod updated successfully";
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

        // DELETE api/<PaymentMethodController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _paymentMethodService.Delete(id);
                oResponse.Data = " PaymentMethod deleted successfully";
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
