using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.Models
{
    public class Admin
    {
        public int AdminId { get; set; }

        [StringLength(20)]
        public string UserName { get; set;}

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
