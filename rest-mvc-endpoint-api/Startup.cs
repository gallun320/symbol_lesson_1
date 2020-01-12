using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace rest_mvc_endpoint_api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddMvc(mvcOptions =>
            //{
            //    mvcOptions.EnableEndpointRouting = false;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //SetEndpoints(app);
            SetEndpointsWithControllers(app);
            //SetMvc(app);
        }

        private void SetEndpoints(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        private void SetEndpointsWithControllers(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(points =>
            {
                points.MapAreaControllerRoute(
                    name: "areaController",
                    areaName: "Area",
                    pattern: "Area/{controller=AreaHome}/{action=Index}"
                );

                points.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Endpoint}/{action=Index}/{num?}"
                );

                //points.MapDefaultControllerRoute();
            });
        }


        private void SetMvc(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Mvc}/{action=Index}/{num?}"
                );

                routes.MapRoute(
                    name: "test_int",
                    template: "{controller=Mvc}/{action=Get}/{num:int:min(1)}"
                );

                routes.MapRoute(
                    name: "test_length",
                    template: "{controller=Mvc}/{action=PostStr}/{str:maxlength(4)}"
                );

            });
        }
    }
}
