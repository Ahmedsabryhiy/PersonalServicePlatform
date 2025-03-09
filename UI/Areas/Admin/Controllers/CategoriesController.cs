using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var listCategories = _categoryService.GetAll();
            return View(listCategories );
        }
        public IActionResult Edit(int? id)
        {
            var category = new TbCategoryDTO();
            if (id != null)
            {
                category = _categoryService.GetById(Convert.ToInt32(id));
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbCategoryDTO category)
        {
            if (!ModelState.IsValid)
                return View("Edit", category);
            if (category.Id == 0)
            {
                _categoryService.Add(category);
            }
            else
            {
                _categoryService.Update(category);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
