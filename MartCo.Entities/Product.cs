﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartCo.Entities
{
    public class Product : BaseEntity
    {
      //  public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public decimal Price { get; set; }

    }
}
