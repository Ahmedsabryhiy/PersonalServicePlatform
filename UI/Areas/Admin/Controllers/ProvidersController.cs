using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProvidersController : Controller
    {
        private readonly IProviderService _providerService;
        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService;
        }
        public IActionResult Index()
        {
            var listProviders = _providerService.GetAll();
            return View( listProviders);
        }
        public IActionResult Edit(int? id)
        {
            var provider = new TbProviderProfileDTO();
            if (id != null)
            {
                provider = _providerService.GetById(Convert.ToInt32(id));
            }
            return View(provider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbProviderProfileDTO provider)
        {
            if (!ModelState.IsValid)
                return View("Edit", provider);
            if (provider.Id == 0)
            {
                _providerService.Add(provider);
            }
            else
            {
                _providerService.Update(provider);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _providerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
