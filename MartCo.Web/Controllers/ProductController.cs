using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MartCo.Entities;
using MartCo.Services;
using MartCo.Web.ViewModels;

namespace MartCo.Web.Controllers
{
    public class ProductController : Controller
    {
        //ProductsService productsService = new ProductsService();


        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search, int? pageNo )
        { 
            ProductSearchViewModel model = new ProductSearchViewModel();

            model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ?  pageNo.Value : 1 : 1;

            model.Products = ProductsService.Instance.GetProducts(model.PageNo.Value);


            if (!string.IsNullOrEmpty(search))
            {
                model.SearchTerm = search;
                model.Products = model.Products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView(model);
        }

        [HttpGet]
        // GET: Category
        public ActionResult Create()
        {
            CategoriesService categoriesService = new CategoriesService();

            var categories = categoriesService.GetCategories();

            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            CategoriesService categoriesService = new CategoriesService();

            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
          //  newProduct.Category = model.CategoryID;
            newProduct.Category = categoriesService.GetCategory(model.CategoryID);

            ProductsService.Instance.SaveProduct(newProduct);

            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = ProductsService.Instance.GetProduct(ID);

            return PartialView(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ProductsService.Instance.UpdateProduct(product);

            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductsService.Instance.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }
    }
}