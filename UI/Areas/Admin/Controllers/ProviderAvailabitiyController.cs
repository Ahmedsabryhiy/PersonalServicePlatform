using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProviderAvailabitiyController : Controller
    {
        private readonly IProviderAvailabilityService _providerAvailabilityService;
        private readonly IProviderService _providerService;
        private readonly IServicesService _servicesService;
        public ProviderAvailabitiyController(IProviderAvailabilityService providerAvailabilityService, IProviderService providerService, IServicesService servicesService)
        {
            _providerAvailabilityService = providerAvailabilityService;
            _providerService = providerService;
            _servicesService = servicesService;
        }

        public IActionResult Index()
        {
            var listProviderAvailabilities = _providerAvailabilityService.GetAll();
       
          
            return View( listProviderAvailabilities );
        }
        public IActionResult Edit(int? id)
        {
            var listProviders = new SelectList(_providerService.GetAll(), "Id", "FullName");
            ViewBag.ListProviders = listProviders;
            var listServices = new SelectList(_servicesService.GetAll(), "Id", "Name");
            ViewBag.ListServices = listServices;
            var providerAvailability = new TbProviderAvailabilityDTO();
            if (id != null)
            {
                providerAvailability = _providerAvailabilityService.GetById(Convert.ToInt32(id));
            }
            return View(providerAvailability);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbProviderAvailabilityDTO providerAvailability)
        {
            if (!ModelState.IsValid)
                return View("Edit", providerAvailability);
            if (providerAvailability.Id == 0)
            {
                _providerAvailabilityService.Add(providerAvailability);
            }
            else
            {
                _providerAvailabilityService.Update(providerAvailability);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _providerAvailabilityService.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
