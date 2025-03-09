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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService =reviewService ;
        }
        // GET: api/<ReviewController>
        [HttpGet]
        public ApiResponse GetAll()
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                var listReviews = _reviewService.GetAll();

                oResponse.Data = listReviews;
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

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                var review = _reviewService.GetById(id);
                oResponse.Data =review;
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
        public ApiResponse Post([FromBody]  TbReviewDTO reviewDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _reviewService.Add(reviewDTO );
                oResponse.Data = "AddedReview successfully";
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


        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] TbReviewDTO reviewDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                if (id !=reviewDTO .Id)
                {
                    oResponse.Data = null;
                    oResponse.Errors = "Mismatched Review ID.";
                    oResponse.StatusCode = 400; // Bad Request
                    return oResponse;
                }
                else
                {
                    _reviewService.Update(reviewDTO );
                    oResponse.Data = "Review updated successfully";
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

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _reviewService.Delete(id);
                oResponse.Data = "Review deleted successfully";
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
