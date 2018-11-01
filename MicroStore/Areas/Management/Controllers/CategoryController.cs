using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroStore.Interfaces;
using MicroStore.Models;
using MicroStore.Models.ViewModels;

namespace MicroStore.Areas.Management.Controllers
{
    [Area("Management")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;

        [BindProperty]
        public CategoryViewModel CategoryViewModel { get; set; }

        public CategoryController(ICategoryRepository category)
        {
            _category = category;

            CategoryViewModel = new CategoryViewModel()
            {
                Categories = _category.List(),
                Category = new Category()
            };
        }

        public IActionResult Index()
        {
            var categories = _category.List();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View(CategoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _category.Create(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();

            CategoryViewModel.Category = _category.Find(id);
            if (CategoryViewModel == null) return NotFound();

            return View(CategoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Category category)
        {
            category = _category.Find(id);

            if (id != category.Id) return NotFound();

            if (ModelState.IsValid)
            {
                category.Name = CategoryViewModel.Category.Name;
                category.ParentId = CategoryViewModel.Category.ParentId;
                category.DisplayOrder = CategoryViewModel.Category.DisplayOrder;

                _category.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(CategoryViewModel);
        }

        public IActionResult Show(int? id)
        {
            if (id == null) return NotFound();

            CategoryViewModel.Category = _category.Find(id);
            if (CategoryViewModel == null) return NotFound();

            return View(CategoryViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            CategoryViewModel.Category = _category.Find(id);
            if (CategoryViewModel == null) return NotFound();

            return View(CategoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _category.Find(id);
            _category.Delete(category);

            return RedirectToAction(nameof(Index));
        }
    }
}