using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ServicesController : Controller
    {
        private readonly IServicesService _services;
        private readonly IProviderService _provider;
        private readonly ICategoryService _category;
        public ServicesController(IServicesService services, IProviderService provider, ICategoryService category)
        {
            _services = services;
            _provider = provider;
            _category = category;
        }
        public IActionResult Index()
        {
            var listServices = _services.GetAll();
            return View(listServices);
        }
        public IActionResult Edit(int? id)
        {
             var listProviders = new SelectList(_provider.GetAll(), "Id", "Name");
            ViewBag.ListProviders = listProviders;

            var listCategories = new SelectList(_category.GetAll(), "Id", "Name");
            ViewBag.ListCategories = listCategories;
            var service = new TbServiceDTO();
            if (id != null)
            {

                service = _services.GetById(Convert.ToInt32(id));
            }
            return View(service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbServiceDTO service)
        {
            if (!ModelState.IsValid)
                return View("Edit", service);
            if (service.Id == 0)
            {
                _services.Add(service);

            }
            else
            {
                _services.Update(service);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _services.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
