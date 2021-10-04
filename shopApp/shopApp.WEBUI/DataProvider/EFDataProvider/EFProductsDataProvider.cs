

using shopApp.WEBUI.Context;
using shopApp.WEBUI.DataProvider.IDataProvider;
using shopApp.WEBUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.DataProvider.EFDataProvider
{
    public class EFProductsDataProvider:IProductDataProvider
    {
        public string Add(Products products)
        {
            using (var mcontext = new ProductDbContext())
            {
                mcontext.Products.Add(products);
                mcontext.SaveChanges();
            }
            return "The product record is successfully saved.";
        }

        public List<Products> GetList()
        {
            using (var mcontext = new ProductDbContext())
            {
                var result = mcontext.Products.ToList();
                return result;
            }
        }

        public Products Get(int id)
        {
            using( var mcontext = new ProductDbContext())
            {
                var result = mcontext.Products.FirstOrDefault(f => f.ProductId == id);
                return result;
            }
        }
        public void Edit(Products products)
        {
            using (var mcontext = new ProductDbContext())
            {
                mcontext.Products.Update(products);

                mcontext.SaveChanges();
            }
        }
        public void Delete(Products products)
        {
            using(var mcontext = new ProductDbContext())
            {
                mcontext.Products.Remove(products);

                mcontext.SaveChanges();
            }
        }
 
    }
}
