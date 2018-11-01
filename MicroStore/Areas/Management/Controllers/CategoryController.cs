using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroStore.Interfaces;

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
    }
}