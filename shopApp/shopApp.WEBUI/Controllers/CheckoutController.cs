using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shopApp.WEBUI.Helper;
using shopApp.WEBUI.Models;

namespace shopApp.WEBUI.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {

            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.product.Price * item.Quantity);


            return View();
        }
    }
}