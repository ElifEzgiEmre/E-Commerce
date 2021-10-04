using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopApp.WEBUI.Data;
using shopApp.WEBUI.DataProvider.IDataProvider;
using shopApp.WEBUI.Entities;
using shopApp.WEBUI.Models;
using shopApp.WEBUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.Controllers
{
    public class ProductController: Controller
    {
        //localhost:5000/product/list   

        IProductDataProvider _productDataProvider;

        public ProductController(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        //public IActionResult List(int? id, string q)
        //{

        //    // product/list => tüm ürünler
        //    // product/list/2 => 2 numaralı kategorideki ürünler
        //  //  Console.WriteLine(q);

        //    var products = ProductRepository.Products;

        //    if (id != null)
        //    {
        //        products = products.Where(p => p.CategoryId == id).ToList();
        //    }

        //    if (!string.IsNullOrEmpty(q))
        //    {
        //        products = products.Where(i => i.Name.Contains(q) || i.Description.Contains(q)).ToList();
        //    }

        //    var productViewModel = new ProductViewModel()
        //    {

        //        Products = products

        //    };

        //     return View(productViewModel);

        //}

        public IActionResult List(int? id, string q)
        {
            var result = _productDataProvider.GetList();

            if (id != null)
                  {
                       result = result.Where(p => p.CategoryId == id).ToList();
                   }

            if (!string.IsNullOrEmpty(q))
                    {
                        result = result.Where(i => i.Name.Contains(q) || i.Description.Contains(q)).ToList();
                    }
                return View(result);
        }

        public IActionResult Index()
        {

            var pro = new Product { Name = "Iphone", Price = 6000, Description = "güzel telefon" };

            ViewBag.Category = "Telefonlar";
            ViewBag.Product = pro;
            
            return View();
        }
        public IActionResult Details(int id)
        {
           
            var result = _productDataProvider.Get(id);
            return View(result);
            
        }

        //public IActionResult Create()
        //{
        //    ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");

        //    return View(new Product());
        //}

        //[HttpPost]
        //public IActionResult Create(Product p)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        ProductRepository.AddProduct(p);
        //        return RedirectToAction("List");
        //    }
        //    return View(p);
            
        //}

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View();
        }
        
        [HttpPost]

        public string Create (Products products)
        {
            return _productDataProvider.Add(products);
        }


        //[HttpGet]

        //public IActionResult Edit(int id)
        //{
        //    ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
        //    return View(ProductRepository.GetProductById(id));
        //}

        //[HttpPost]
        //public IActionResult Edit(Product p)
        //{
        //    ProductRepository.EditProduct(p);
        //    return RedirectToAction("List");
        //}

        
        public IActionResult Edit(int id)
        {

                var result = _productDataProvider.Get(id);
                return View(result);
       
        }

        [HttpPost]
        public IActionResult Edit(Products products)
        {
            _productDataProvider.Edit(products);

            return RedirectToAction("List");
        }

        [Authorize]
        public IActionResult Delete(Products products)
        {
            _productDataProvider.Delete(products);

            return RedirectToAction("List");
        }


    }
}
