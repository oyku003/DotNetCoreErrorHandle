using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UdemyErrorHandling.Filter;

namespace UdemyErrorHandling
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc(options=>
            {
                options.Filters.Add(new CustomHandleExceptionFilterAttribute {ErrorPage = "hata1" }); 

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }


        //Request --------[DeveloperExceptionPage]-----------[ExceptionHandler]----------[]--------------------------> Response
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {   
               app.UseDeveloperExceptionPage();//DeveloperExceptionPage

                //1.yol
                // app.UseStatusCodePages("text/plain", "Bir hata var.Durum kodu: {0}");

                app.UseDatabaseErrorPage();
                //2.yol
                //app.UseStatusCodePages(async context=> {
                //    context.HttpContext.Response.ContentType = "text/plain";
                //    await context.HttpContext.Response.WriteAsync($"Bir hata var. Durum kodu {context.HttpContext.Response.StatusCode}");
                //});//context=> {} newleme yerine geciyor
                
                //3.yol
                //app.UseStatusCodePages();
            }
            else
            {
                //app.UseExceptionHandler(context =>
                //{
                //    context.Run(async page =>
                //    {
                //        page.Response.StatusCode = 500;//server taraflı, client taraflı 400, başarlı 200, yönlendirmeler 300 ile başlar
                //        page.Response.ContentType = "text/html";
                //        await page.Response.WriteAsync($"<html><head><h1>Hata var: {page.Response.StatusCode}</h1></head></html>");
                //    });
                    
                //});//app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
