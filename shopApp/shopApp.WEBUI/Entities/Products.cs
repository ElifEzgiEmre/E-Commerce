using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace shopApp.WEBUI.Entities
{
    public class Products
    {
        [DataMember]
        [Column("ProductId"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Ürün isimi için 10-60 karakter arasında olmalıdır.")]
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }


        public bool IsApproved { get; set; }

     
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
    }
}
