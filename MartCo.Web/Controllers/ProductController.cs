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
           // CategoriesService categoriesService = new CategoriesService();

            var categories = CategoriesService.Instance.GetCategories();

            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
            //CategoriesService categoriesService = new CategoriesService();

            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
          //  newProduct.Category = model.CategoryID;
            newProduct.Category = CategoriesService.Instance.GetCategory(model.CategoryID);

            ProductsService.Instance.SaveProduct(newProduct);

            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();

            var product = ProductsService.Instance.GetProduct(ID);

            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.CategoryID = product.Category != null ? product.Category.ID : 0;

            model.AvailableCategories = CategoriesService.Instance.GetCategories();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = ProductsService.Instance.GetProduct(model.ID);
            existingProduct.Name = model.Name;
            existingProduct.Description = model.Description;
            existingProduct.Price = model.Price;
            existingProduct.Category = CategoriesService.Instance.GetCategory(model.CategoryID);

            ProductsService.Instance.UpdateProduct(existingProduct);

            return RedirectToAction("ProductTable");
        }

        //[HttpGet]
        //public ActionResult Edit(int ID)
        //{
        //    var product = ProductsService.Instance.GetProduct(ID);

        //    return PartialView(product);
        //}
        //[HttpPost]
        //public ActionResult Edit(Product product)
        //{
        //    ProductsService.Instance.UpdateProduct(product);

        //    return RedirectToAction("ProductTable");
        //}

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductsService.Instance.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }
    }
}