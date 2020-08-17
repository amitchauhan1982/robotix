using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using robotix.Model;
using robotix.Model.Repository;

namespace robotix
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("robotixdb")));
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

           services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseRouting(); 
           // app.UseMvc(routes => routes.MapRoute("default", "{contoller}/{action}/{id?}"));
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "areas",
                template: "{area:exists}/{contoller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "MyAreaProducts",
                    areaName: "Frontend",
                    template: "Frontend/{contoller}/{action}/{id?}",
                    defaults: new { controller = "home", action = "index" });

                routes.MapRoute(
               name: "default",
               template: "{area:exists}/{contoller=Home}/{action=Index}/{id?}");

            });
            app.UseEndpoints(endpoints =>
            {
            //endpoints.MapGet("/", async context =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            //endpoints.MapControllerRoute(
            //    name : "area",
            //    pattern: "{area:exits}/{controller=Home}/{action=Index}");
            });
        }
    }
}
