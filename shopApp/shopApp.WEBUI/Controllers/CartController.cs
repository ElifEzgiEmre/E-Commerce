using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopApp.WEBUI.DataProvider.IDataProvider;
using shopApp.WEBUI.Helper;
using shopApp.WEBUI.Models;

namespace shopApp.WEBUI.Controllers
{
    public class CartController : Controller
    {
        IProductDataProvider _productDataProvider;

        public CartController(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            
                ViewBag.total = cart.Sum(item => item.product.Price * item.Quantity);
            
        

            return View();
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for(int i= 0; i < cart.Count; i++)
            {
                if (cart[i].product.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        [Authorize]
        public IActionResult Buy(int id)
        {
            if(SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { product = _productDataProvider.Get(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { product = _productDataProvider.Get(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");

        }

        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int result = isExist(id);
            cart.RemoveAt(result);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
    }
}