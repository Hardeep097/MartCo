using MartCo.Services;
using MartCo.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MartCo.Web.Controllers
{
    public class ShopController : Controller
    {
        //ProductsService productService = new ProductsService();
        // GET: Shop
        public ActionResult Checkout()
        {
            var CartProductsCookie = Request.Cookies["CartProducts"];

            CheckoutViewModels model = new CheckoutViewModels();

            if (CartProductsCookie != null)
            {
                //var productIDs = CartProductsCookie.Value;
                //var ids = productIDs.Split('-');

                //List<int> pIDs = ids.Select(x => int.Parse(x)).ToList();

                model.CartProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();

               model.CartProducts =  ProductsService.Instance.GetProducts(model.CartProductIDs);
            }
            return View(model); 
        }
    }
}