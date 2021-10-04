
using Microsoft.EntityFrameworkCore;
using shopApp.WEBUI.Entities;
using shopApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.Context
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = ProductDb; Trusted_connection = True; MultipleActiveResultSets = true");
     
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
