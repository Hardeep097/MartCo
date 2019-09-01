using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartCo.Entities
{
    public class Config
    {
        [Key]
        public String Key { get; set; }
        public string Value { get; set; }

    }
}
