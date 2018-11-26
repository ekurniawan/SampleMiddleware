using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SampleMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (content, next) =>
            {
                if (content.Request.Path.Value.Contains("home"))
                {
                    await content.Response.WriteAsync("Response to home");
                }
                else
                {
                    Debug.WriteLine("==Before Run==");
                    await next.Invoke();
                    Debug.WriteLine("==After Run==");
                }
            });

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                Debug.WriteLine("===During Run===");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
