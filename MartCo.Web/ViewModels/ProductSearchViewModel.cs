using MartCo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartCo.Web.ViewModels
{
    public class ProductSearchViewModel
    {
        public int? PageNo { get; internal set; }
        public List<Product> Products { get; set; }
        public string SearchTerm { get; set; }

    }

    public class NewProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }

        public List<Category> AvailableCategories { get; set; }
    }
}