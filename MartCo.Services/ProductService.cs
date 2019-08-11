using MartCo.Database;
using MartCo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartCo.Services
{
    public class ProductsService
    {
        public Product GetProduct(int ID)
        {
            using(var context = new MCContext())
            {
              return  context.Products.Find(ID);
            }
        }

        public List<Product> GetProducts()
        {
            using(var context = new MCContext())
            {
              return  context.Products.ToList();
            }
        }
        

        public void SaveProduct(Product product)
        {
            using(var context = new MCContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using(var context = new MCContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using(var context = new MCContext())
            {
                // context.Entry(product).State = System.Data.Entity.EntityState.Deleted; or 

                var product = context.Products.Find(ID);
                context.Products.Remove(product);

                context.SaveChanges();
            }
        }
    }
}
