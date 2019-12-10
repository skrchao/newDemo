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
using Tutorial.Web.Model;
using Tutorial.Web.Services;

namespace Tutorial.Web
{
    public class Startup
    {
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IWebService,WebService>();
            services.AddScoped<IRepository<Student>, InMemoryRepositoty>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IWebService webservice, ILogger<Startup> logger)
        {
            #region
            //app.Use(next =>
            //{
            //    logger.LogInformation("user logger ........");
            //    return async httpContext =>
            //    {
            //        if (httpContext.Request.Path.StartsWithSegments("/first"))
            //        {
            //            await httpContext.Response.WriteAsync("First!!!!");
            //        }
            //        else
            //        {
            //            await next(httpContext);
            //        }
            //    };
            //});
            //app.UseWelcomePage(new WelcomePageOptions()
            //{
            //    Path = "/welcome"
            //}) ;
            #endregion
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();

            app.UseMvcWithDefaultRoute();
            app.UseMvc(builder =>
            {
                builder.MapRoute("Default", "{controller}/{action}/{id?}");
            });

            //app.Run(async (context) =>
            //{
            //    //throw new Exception("Error");
            //    var mes = webservice.GetMessage();
            //    await context.Response.WriteAsync(mes);
            //});
        }
    }
}
