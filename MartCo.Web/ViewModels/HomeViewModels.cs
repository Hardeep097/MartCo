﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MartCo.Entities;

namespace MartCo.Web.ViewModels
{
    public class HomeViewModels
    {
        public List<Category> FeaturedCategories { get; set; }
        public List<Product> FeaturedProducts { get; set; }
    }
}