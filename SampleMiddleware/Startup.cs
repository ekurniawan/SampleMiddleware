using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
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
                "{controller=Home}/{action=About}/{id?}");
        }
    }
}
