﻿using shopApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.Data
{
    public class CategoryRepository
    {
        private static List<Category> _categories = null;

        static CategoryRepository()
        {
            _categories = new List<Category> 
            {
            new Category { CategoryId=1, Name = "Küpe", Description = "Küpe Kategorisi" },
            new Category { CategoryId=2, Name = "Kolye", Description = "Kolye Kategorisi" },
            new Category { CategoryId=3, Name = "Bileklik", Description = "Bileklik Kategorisi" }


            };
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public static Category GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}
