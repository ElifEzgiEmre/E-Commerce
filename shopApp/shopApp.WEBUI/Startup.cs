using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shopApp.WEBUI.Context;
using shopApp.WEBUI.DataProvider.EFDataProvider;
using shopApp.WEBUI.DataProvider.IDataProvider;
using shopApp.WEBUI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace shopApp.WEBUI
{
    public class Startup
    {

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //mvc
            // services.AddControllersWithViews();

            services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductDbContext")));
            services.AddTransient<IProductDataProvider, EFProductsDataProvider>();

            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductDbContext")));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/User/Login";
                });
            services.AddMvc(config=>
            {
                var policy = new AuthorizationPolicyBuilder()
                               .RequireAuthenticatedUser()
                               .Build();
                config.Filters.Add(new Authorize)
            })
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();//wwwroot -> Middleware

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
           
            app.UseAuthorization();
           
            //localhost:5000/product/list
            //localhost:5000/product/list/2

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                  );

              
            });
        }
    }
}
