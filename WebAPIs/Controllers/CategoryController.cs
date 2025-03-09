using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoryServiceController>
        [HttpGet]

        public ApiResponse GetAll()
        {

            ApiResponse oResponse = new ApiResponse();
            try
            {
                var listCategories = _categoryService.GetAll();
                oResponse.Data = listCategories;
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

        // GET api/<CategoryServiceController>/5
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                var CategoryService = _categoryService.GetById(id);
                oResponse.Data = CategoryService;
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

        // POST api/<CategoryServiceController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbCategoryDTO CategoryDto)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _categoryService.Add(CategoryDto);
                oResponse.Data = "Added Category successfully";
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

        // PUT api/<CategoryServiceController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] TbCategoryDTO CategoryDTO)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                if (id != CategoryDTO.Id)
                {
                    oResponse.Data = null;
                    oResponse.Errors = "Mismatched Category ID.";
                    oResponse.StatusCode = 400; // Bad Request
                    return oResponse;
                }
                else
                {
                    _categoryService.Update(CategoryDTO);
                    oResponse.Data = "Category updated successfully";
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

        // DELETE api/<CategoryServiceController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse oResponse = new ApiResponse();
            try
            {
                _categoryService.Delete(id);
                oResponse.Data = " Category deleted successfully";
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
