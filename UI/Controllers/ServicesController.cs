using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServicesService _servicesService;
        private readonly ICategoryService _categoryService;

        public ServicesController(IServicesService servicesService, ICategoryService categoryService)
        {
            _servicesService = servicesService;
            _categoryService = categoryService;
        }
        public IActionResult Index( string searchTerm, int? categoryId)
        {
            ViewBag.Categories = _categoryService.GetAll();

            var  services = _servicesService.GetAll();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                 services = _servicesService.Search(searchTerm);
            }
            if (categoryId.HasValue)
            {
                services = _servicesService.GetByCategory(categoryId.Value);
            }
            return View(services);
            
        }

    }
}
