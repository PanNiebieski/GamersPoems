using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GamersPoems.Services.Interface;

using GamersPoems.Services;
using Microsoft.AspNetCore.Routing;

namespace GamersPoems
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IGamesData, GamesData>();
            services.AddSingleton<IMessages, Messages>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder app,
            IHostingEnvironment enviroment,
            IMessages messages)
        {
            //app.UseIISPlatformHandler();

            if (enviroment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //app.UseRuntimeInfoPage("/info");
                app.UseWelcomePage("/IIS");
            }

            app.UseStaticFiles();

            app.UseMvc(SetRoutes);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messages.Hello());
            });
        }

        private void SetRoutes(IRouteBuilder routeBuilder)
        {
            // Home / Index
            routeBuilder.MapRoute("MyDefault",
                "{controller=Home}/{action=Index}/{id?}");
        }

    }
}
