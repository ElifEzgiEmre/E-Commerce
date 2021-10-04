using Microsoft.AspNetCore.Mvc;
using shopApp.WEBUI.Data;
using shopApp.WEBUI.DataProvider.IDataProvider;
using shopApp.WEBUI.Models;
using shopApp.WEBUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.Controllers
{
    //localhost:5000/home/index
    public class HomeController:Controller
    {
       
        IProductDataProvider _productDataProvider;

        public HomeController(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }
        //public IActionResult Index()
        //{



        //    var productViewModel = new ProductViewModel()
        //    {

        //        Products = ProductRepository.Products

        //    };

        //    return View(productViewModel);
        //}
        public IActionResult Index()
        {
            var result = _productDataProvider.GetList();

            return View(result);
        }
        //public IActionResult AddToCart(int productid)
        //{
        //    var cart = new List<Item>();
        //    var product = _productDataProvider.Get(productid);

        //    cart.Add(new Item()
        //    {
        //        product = product,
        //        Quantity=1

        //    });
        //    Session["cart"] = cart;
        //    return View();
        //}


        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View("MyView");

        }
    }
}
