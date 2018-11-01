using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroStore.Interfaces;
using MicroStore.Models;

namespace MicroStore.Areas.Management.Controllers
{
    [Area("Management")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;

        public CategoryController(ICategoryRepository category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            var categories = _category.List();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
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

            Category category = _category.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Category category)
        {
            if (id != category.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _category.Update(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Show(int? id)
        {
            if (id == null) return NotFound();

            Category category = _category.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Category category = _category.Find(id);
            if (category == null) return NotFound();

            return View(category);
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