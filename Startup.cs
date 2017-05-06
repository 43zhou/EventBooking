using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EventBookingSystem.Models;

namespace EventBookingSystem
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder() 
                .SetBasePath(env.ContentRootPath) 
                .AddJsonFile("appsettings.json")
                .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options 
                => options.UseMySql(Configuration["Data:EventBookingSystem:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options 
                => options.UseMySql(Configuration["Data:EventBookingSystemIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>() 
                .AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddTransient<ICreatedEventRepository, EFCreatedEventRepository>();
            services.AddTransient<IParticipationRepository, EFParticipationRepository>();
            // //services.AddScoped<Cart>(sp => SessionCart.GetCart(sp)); 
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // services.AddTransient<IParticipateRepository, EFParticipateRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            //This extension method adds a simple message to HTTP responses that 
            //would not otherwise have a body, such as 404 - Not Found responses.
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseSession();
            app.UseIdentity();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "Error", 
                    template: "Error", 
                    defaults: new { controller = "Error", action = "Error" }
                );
                routes.MapRoute(
                    name:null,
                    template:"{category}/Page{page:int}",
                    defaults: new {Controller="Home", action="Index"}
                );
                routes.MapRoute( 
                    name: null, 
                    template: "Page{page:int}", 
                    defaults: new { controller = "Home", action = "Index", page = 1 } );
                routes.MapRoute( 
                    name: null, 
                    template: "{category}", 
                    defaults: new { controller = "Home", action = "Index", page = 1 } );
                routes.MapRoute(
                    name: null, 
                    template: "", 
                    defaults: new { controller = "Home", action = "Index", page = 1 });
                routes.MapRoute(
                    name: null, 
                    template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
