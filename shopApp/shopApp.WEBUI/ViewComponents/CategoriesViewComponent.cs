using Microsoft.AspNetCore.Mvc;
using shopApp.WEBUI.Data;
using shopApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.ViewComponents
{
    public class CategoriesViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if(RouteData.Values["action"].ToString() == "List")
            {
                ViewBag.SelectedCategory = RouteData?.Values["id"];
            }

            return View(CategoryRepository.Categories);
        }
    }
}
