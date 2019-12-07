using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DemoCore
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<ICinemaService, CinemaMemoryService>();
            services.AddSingleton<IMovieService, MovieMemoryService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup>logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();//显示错误到页面

            app.UseStaticFiles();//加载静态文件

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });





            #region
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("m1 start");
            //    await context.Response.WriteAsync("Hello World!");
            //    await next();
            //    logger.LogInformation("m1 end");

            //});
            //app.Run(async (context) =>
            //{
            //    logger.LogInformation("m2 start");
            //    await context.Response.WriteAsync("Another Hello!");
            //    logger.LogInformation("m2 end");
            //});
            #endregion
        }
    }
}
