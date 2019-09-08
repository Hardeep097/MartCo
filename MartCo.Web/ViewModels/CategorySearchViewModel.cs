using MartCo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartCo.Web.ViewModels
{
    public class CategorySearchViewModel
    {
        public List<Category> Categories { get; set; }

        public String SearchTerm { get; set; }
    }
}