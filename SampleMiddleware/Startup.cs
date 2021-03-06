﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleMiddleware.Data;
using SampleMiddleware.Services;

namespace SampleMiddleware
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            //services.AddScoped<IRestaurantData, RestaurantData>();
            services.AddScoped<IRestaurantData, RestaurantDataEF>();

            services.AddDbContext<RestaurantDbContext>(options =>
            options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<RestaurantDbContext>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
             IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //{controller=Home}/{action=Index}
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Data: {greeter.GetMessageOfTheDay()}");
            });
        }

        private void ConfigureRoutes(IRouteBuilder obj)
        {
            obj.MapRoute(name: "blog", template: "blog/{article}",
                defaults: new { controller = "Home", action = "ReadArticle" });
            obj.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
