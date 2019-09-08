using MartCo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartCo.Web.ViewModels
{
    public class EditProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public List<Category> AvailableCategories { get; internal set; }
    }
}