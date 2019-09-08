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
        //CategoriesService categoryService = new CategoriesService();

        //#region Singleton
        //public static CategoryController Instance
        //{
        //    get
        //    {
        //        if (instance == null) instance = new CategoryController();

        //        return instance;

        //    }
        //}
        //private static CategoryController instance { get; set; }
        //private CategoryController()
        //{

        //}
        //#endregion

        [HttpGet]
        // GET: Category
        public ActionResult Index()
        {
            //var categories = CategoriesService.Instance.GetCategories();
            return View();
        }

        public ActionResult CategoryTable(string search)
        {
            CategorySearchViewModel model = new CategorySearchViewModel
            {
                Categories = CategoriesService.Instance.GetCategories( )
            };

            if (!string.IsNullOrEmpty(search))
            {
                model.SearchTerm = search;

                model.Categories = model.Categories.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
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
        public ActionResult Create(NewCategoryViewModel model)
        {

            var newCategory = new Category();

            
            newCategory.Name = model.Name;
            newCategory.Description = model.Description;
            newCategory.ImageURL = model.ImageURL;
            newCategory.isFeatured = model.isFeatured;

            CategoriesService.Instance.SaveCategory(newCategory);

            return RedirectToAction("CategoryTable");
        }

        //[HttpPost]
        //public ActionResult Create(Category category)
        //{
        //    CategoriesService.Instance.SaveCategory(category);

        //    return RedirectToAction("CategoryTable");
        //}

        [HttpGet]
        // GET: Category
        public ActionResult Edit(int ID)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();

            var category = CategoriesService.Instance.GetCategory(ID);

            model.ID = category.ID;
            model.Name = category.Name;
            model.Description = category.Description;
            model.ImageURL = category.ImageURL;
            model.isFeatured = category.isFeatured;

            return PartialView(model); ;
        }
        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {

            var existngCategory = CategoriesService.Instance.GetCategory(model.ID);
            
            existngCategory.Name = model.Name;
            existngCategory.Description = model.Description;
            existngCategory.ImageURL = model.ImageURL;
            existngCategory.isFeatured = model.isFeatured;

            CategoriesService.Instance.UpdateCategory(existngCategory);

            return RedirectToAction("CategoryTable");
        }
        //[HttpPost]
        //public ActionResult Edit(Category category)
        //{
        //   // EditCategoryViewModel model = new EditCategoryViewModel()

        //    CategoriesService.Instance.UpdateCategory(category);

        //    return RedirectToAction("CategoryTable");
        //}

        [HttpGet]
        // GET: Category
        public ActionResult Delete(int ID)
        {
            var category = CategoriesService.Instance.GetCategory(ID);

            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {

            CategoriesService.Instance.DeleteCategory(category.ID);

            return RedirectToAction("Index");
        }
    }
}