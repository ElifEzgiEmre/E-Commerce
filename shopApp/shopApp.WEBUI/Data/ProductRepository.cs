using shopApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.Data
{
    public static class ProductRepository
    {
        private static List<Product> _products = null;

        static ProductRepository()
        {
            _products = new List<Product> 
            {
                new Product { ProductId=1,Name = "Altın Renk İncili Taşlı Küpe (Çift)", Price = 50, Description = "Gösterişli ve şık modeldir.Tende kararma yapmaz.Krem, parfüm, alkol gibi maddeler ile temasından kaçınılmalıdır.",IsApproved =true,ImageUrl="1.jpg",CategoryId=1},
                new Product { ProductId=2,Name = "Gümüş Renk Fiyonk Detaylı Zincir Küpe (Çift)", Price = 60, Description = "Kombinlerinizi tamamlayacak küpe modelidir.Gösterişli ve şık modeldir",IsApproved= false,ImageUrl="2.jpg",CategoryId=1},
                new Product { ProductId=3,Name = "Altın Renk Çubuk Detaylı Taşlı Küpe", Price = 35, Description = "Gösterişli ve şık modeldir.Tende kararma yapmaz.",IsApproved= false,ImageUrl="3.jpg",CategoryId=1},
                new Product { ProductId=4,Name = "Yıldız Figürlü Mıknatıslı Küpe", Price = 15, Description = "Ağırlık: 2.8 gr Uzunluk: 1 cm Mıknatıslıdır.Tende kararma ve paslanma yapmaz, uzun süre kullanıma uygundur.",IsApproved= false,ImageUrl="4.jpg",CategoryId=1},

                new Product { ProductId=5,Name = "Gümüş Renk Deniz Kabuğu Figürlü İnci Detaylı kolye", Price = 50, Description = "Zinciri ayarlanabilir. Kaliteli çelikten üretilmiştir. Renk kaplamadır, tende kararma veya paslanma yapmaz.",IsApproved =true,ImageUrl="5.jpg",CategoryId=2},
                new Product { ProductId=6,Name = "Rose Renk Deniz Yıldızı Figürlü Kolye", Price = 60, Description = "Kapanma kısmı klipslidir. Zincir boyu ayarlanabilir, ister dar ister geniş takabilirsiniz.Tende kararma ve paslanma yapmaz, rengi boya değil kaplamadır. ",IsApproved= false,ImageUrl="6.jpg",CategoryId=2},

                new Product { ProductId=7,Name = "Altın Renk Yonca Figürlü Şahmeran", Price = 35, Description = "Gösterişli ve şık modeldir.Tende kararma yapmaz.Krem, parfüm, alkol gibi maddeler ile temasından kaçınılmalıdır.",IsApproved= false,ImageUrl="7.jpg",CategoryId=3},
                new Product { ProductId=8,Name = "Zirkon Taşlı Ve İnci Detaylı Bileklik", Price = 15, Description = "Tende kararma yapmaz.Krem, parfüm, alkol gibi maddeler ile temasından kaçınılmalıdır.",IsApproved= false,ImageUrl="8.jpg",CategoryId=3}
            };
        }
        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }


        public static Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }

        public static void EditProduct(Product product)
        {
            foreach (var p in _products)
            {
                if(p.ProductId == product.ProductId)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.Description = product.Description;
                    p.ImageUrl = product.ImageUrl;
                    p.IsApproved = product.IsApproved;
                    p.CategoryId = product.CategoryId;
                }
            }
        }

        public static void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            

            if(product != null)
            {
                _products.Remove(product);
                
            }
        }
    }
}
