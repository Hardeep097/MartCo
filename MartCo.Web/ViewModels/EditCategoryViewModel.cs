using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartCo.Web.ViewModels
{
    public class EditCategoryViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public bool isFeatured { get; set; }

    }
}