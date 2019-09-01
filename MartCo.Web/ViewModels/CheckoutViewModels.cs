using MartCo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartCo.Web.ViewModels
{
    public class CheckoutViewModels
    {

        public List<Product> CartProducts { get; set; }

        public List<int> CartProductIDs { get; set; }
    }
}