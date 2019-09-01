using MartCo.Entities;
using MartCo.Services;
using MartCo.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MartCo.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoryService = new CategoriesService();


        [HttpGet]
        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }

        public ActionResult CategoryTable(string search)
        {
            CategorySearchViewModel model = new CategorySearchViewModel
            {
                Categories = categoryService.GetCategories()
            };

            if (!string.IsNullOrEmpty(search))
            {
                model.SearchTerm = model.Categories.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView(model);
        }


        [HttpGet]
        // GET: Category
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);

            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        // GET: Category
        public ActionResult Edit(int ID)
        {
            var category = categoryService.GetCategory(ID);

            return PartialView(category); ;
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);

            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        // GET: Category
        public ActionResult Delete(int ID)
        {
            var category = categoryService.GetCategory(ID);

            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {

            categoryService.DeleteCategory(category.ID);

            return RedirectToAction("Index");
        }
    }
}